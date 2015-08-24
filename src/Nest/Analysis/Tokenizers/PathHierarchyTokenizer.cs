﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nest
{
	/// <summary>
	/// The path_hierarchy tokenizer takes something like this:
	///<para>/something/something/else</para>
	///<para>And produces tokens:</para>
	///<para></para>
	///<para>/something</para>
	///<para>/something/something</para>
	///<para>/something/something/else</para>
	/// </summary>
	public interface IPathHierarchyTokenizer : ITokenizer
	{
		/// <summary>
		/// The character delimiter to use, defaults to /.
		/// </summary>
		[JsonProperty("delimiter")]
		string Delimiter { get; set; }

		/// <summary>
		/// An optional replacement character to use. Defaults to the delimiter
		/// </summary>
		[JsonProperty("replacement")]
		string Replacement { get; set; }

		/// <summary>
		/// The buffer size to use, defaults to 1024.
		/// </summary>
		[JsonProperty("buffer_size")]
		int? BufferSize { get; set; }

		/// <summary>
		/// Generates tokens in reverse order, defaults to false.
		/// </summary>
		[JsonProperty("reverse")]
		bool? Reverse { get; set; }

		/// <summary>
		/// Controls initial tokens to skip, defaults to 0.
		/// </summary>
		[JsonProperty("skip")]
		int? Skip { get; set; }	
	}

	/// <inheritdoc/>
	public class PathHierarchyTokenizer : TokenizerBase, IPathHierarchyTokenizer
    {
		public PathHierarchyTokenizer() { Type = "path_hierarchy"; }

		/// <summary/>
		public string Delimiter { get; set; }

		/// <summary/>
		public string Replacement { get; set; }

		/// <summary/>
		public int? BufferSize { get; set; }

		/// <summary/>
		public bool? Reverse { get; set; }

		/// <summary/>
		public int? Skip { get; set; }	
    }
	/// <inheritdoc/>
	public class PathHierarchyTokenizerDescriptor 
		: TokenizerDescriptorBase<PathHierarchyTokenizerDescriptor, IPathHierarchyTokenizer>, IPathHierarchyTokenizer
	{
		protected override string Type => "path_hierarchy";

		int? IPathHierarchyTokenizer.BufferSize { get; set; }
		int? IPathHierarchyTokenizer.Skip { get; set; }
		bool? IPathHierarchyTokenizer.Reverse { get; set; }
		string IPathHierarchyTokenizer.Delimiter { get; set; }
		string IPathHierarchyTokenizer.Replacement { get; set; }

		/// <inheritdoc/>
		public PathHierarchyTokenizerDescriptor BufferSize(int? bufferSize) => Assign(a => a.BufferSize = bufferSize);

		/// <inheritdoc/>
		public PathHierarchyTokenizerDescriptor Skip(int? skip) => Assign(a => a.Skip = skip);

		/// <inheritdoc/>
		public PathHierarchyTokenizerDescriptor Reverse(bool? reverse = true) => Assign(a => a.Reverse = reverse);

		/// <inheritdoc/>
		public PathHierarchyTokenizerDescriptor Delimiter(string delimiter) => Assign(a => a.Delimiter = delimiter);

		/// <inheritdoc/>
		public PathHierarchyTokenizerDescriptor Replacement(string replacement) => 
			Assign(a => a.Replacement = replacement);

	}
}