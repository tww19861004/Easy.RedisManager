﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Common
{
    public class JsonObject : Dictionary<string, string>
    {
        /// <summary>
        /// Get JSON string value
        /// </summary>
        public new string this[string key]
        {
            get { return this.Get(key); }
            set { base[key] = value; }
        }

        public static JsonObject Parse(string json)
        {
            return JsonSerializer.DeserializeFromString<JsonObject>(json);
        }

        public static JsonArrayObjects ParseArray(string json)
        {
            return JsonArrayObjects.Parse(json);
        }

        public JsonArrayObjects ArrayObjects(string propertyName)
        {
            string strValue;
            return this.TryGetValue(propertyName, out strValue)
                ? JsonArrayObjects.Parse(strValue)
                : null;
        }

        public JsonObject Object(string propertyName)
        {
            string strValue;
            return this.TryGetValue(propertyName, out strValue)
                ? Parse(strValue)
                : null;
        }

        /// <summary>
        /// Get unescaped string value
        /// </summary>
        public string GetUnescaped(string key)
        {
            return base[key];
        }

        /// <summary>
        /// Get unescaped string value
        /// </summary>
        public string Child(string key)
        {
            return base[key];
        }

        static readonly Regex NumberRegEx = new Regex(@"^[0-9]*(?:\.[0-9]*)?$", PclExport.Instance.RegexOptions);

        /// <summary>
        /// Write JSON Array, Object, bool or number values as raw string
        /// </summary>
        public static void WriteValue(TextWriter writer, object value)
        {
            var strValue = value as string;
            if (!string.IsNullOrEmpty(strValue))
            {
                var firstChar = strValue[0];
                var lastChar = strValue[strValue.Length - 1];
                if ((firstChar == JsWriter.MapStartChar && lastChar == JsWriter.MapEndChar)
                    || (firstChar == JsWriter.ListStartChar && lastChar == JsWriter.ListEndChar)
                    || JsonUtils.True == strValue
                    || JsonUtils.False == strValue
                    || NumberRegEx.IsMatch(strValue))
                {
                    writer.Write(strValue);
                    return;
                }
            }
            JsonUtils.WriteString(writer, strValue);
        }
    }

    public class JsonArrayObjects : List<JsonObject>
    {
        public static JsonArrayObjects Parse(string json)
        {
            return JsonSerializer.DeserializeFromString<JsonArrayObjects>(json);
        }
    }

    public interface IValueWriter
    {
        void WriteTo(ITypeSerializer serializer, TextWriter writer);
    }

    public struct JsonValue : IValueWriter
    {
        private readonly string json;

        public JsonValue(string json)
        {
            this.json = json;
        }

        public T As<T>()
        {
            return JsonSerializer.DeserializeFromString<T>(json);
        }

        public override string ToString()
        {
            return json;
        }

        public void WriteTo(ITypeSerializer serializer, TextWriter writer)
        {
            writer.Write(json ?? JsonUtils.Null);
        }
    }
}
