using MessagePack;
using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sketch7.MessagePack.MediaTypeFormatter
{
	/// <summary>
	/// MessagePack media type formatter.
	/// </summary>
	public class MessagePackMediaTypeFormatter : System.Net.Http.Formatting.MediaTypeFormatter
	{
		private const string MediaType = "application/x-msgpack";
		private readonly MessagePackSerializerOptions _options;

		/// <summary>
		/// Initializes a new instance with default formatter resolver.
		/// </summary>
		public MessagePackMediaTypeFormatter()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance with the provided formatter resolver.
		/// </summary>
		/// <param name="options"></param>
		public MessagePackMediaTypeFormatter(MessagePackSerializerOptions? options)
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue(MediaType));
			_options = options ?? MessagePackSerializerOptions.Standard
				.WithCompression(MessagePackCompression.Lz4BlockArray)
				.WithResolver(StandardResolverAllowPrivate.Instance);
		}

		/// <inheritdoc />
		public override bool CanReadType(Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));

			return IsAllowedType(type);
		}

		/// <inheritdoc />
		public override bool CanWriteType(Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			return IsAllowedType(type);
		}

		private static bool IsAllowedType(Type t)
		{
			if (t != null && !t.IsAbstract && !t.IsInterface && !t.IsNotPublic)
				return true;

			if (typeof(IEnumerable<>).IsAssignableFrom(t))
				return true;

			return false;
		}

		/// <inheritdoc />
		public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
		{
			var result = MessagePackSerializer.Deserialize(type, readStream, _options);
			return Task.FromResult(result);
		}

		/// <inheritdoc />
		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
			TransportContext transportContext)
		{
			MessagePackSerializer.Serialize(type, writeStream, value, _options);
			return Task.CompletedTask;
		}
	}
}