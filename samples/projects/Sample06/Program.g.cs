/* This file was automatically generated from code snippets embedded in file Sample06_InspectComplexSchemasEmbedded.md */
/* The associated project file Sample06.csproj and expected output file expect.txt were also automatically generated. */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DTDLParser;
using DTDLParser.Models;

namespace Sample06
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Snippet:DtdlParserSample06_CreateModelParser
            var modelParser = new ModelParser();
            #endregion

            #region Snippet:DtdlParserSample06_ObtainDtdlTextContainingArray
            string jsonText =
            @"{
              ""@context"": ""dtmi:dtdl:context;3"",
              ""@id"": ""dtmi:example:anInterface;1"",
              ""@type"": ""Interface"",
              ""contents"": [
                {
                  ""@type"": ""Property"",
                  ""name"": ""totalLength"",
                  ""schema"": ""double""
                },
                {
                  ""@type"": ""Telemetry"",
                  ""name"": ""lengthPerSegment"",
                  ""schema"": {
                    ""@type"": ""Array"",
                    ""elementSchema"": ""double""
                  }
                }
              ]
            }";
            #endregion

            #region Snippet:DtdlParserSample06_CallParse
            IReadOnlyDictionary<Dtmi, DTEntityInfo> objectModel = modelParser.Parse(jsonText);
            #endregion

            #region Snippet:DtdlParserSample06_GetInterfaceById
            var anInterfaceId = new Dtmi("dtmi:example:anInterface;1");
            var anInterface = (DTInterfaceInfo)objectModel[anInterfaceId];
            #endregion

            #region Snippet:DtdlParserSample06_GetContentsByName
            string totalLengthName = "totalLength";
            var totalLength = (DTPropertyInfo)anInterface.Contents[totalLengthName];

            string lengthPerSegmentName = "lengthPerSegment";
            var lengthPerSegment = (DTTelemetryInfo)anInterface.Contents[lengthPerSegmentName];
            #endregion

            #region Snippet:DtdlParserSample06_DisplayPropertySchema
            Console.WriteLine($"totalLength schema is {totalLength.Schema.Id}");
            #endregion

            #region Snippet:DtdlParserSample06_DisplayPropertySchemaTerm
            Console.WriteLine($"totalLength schema term is {ModelParser.GetTermOrUri(totalLength.Schema.Id)}");
            #endregion

            #region Snippet:DtdlParserSample06_DisplayTelemetrySchema
            Console.WriteLine($"lengthPerSegment schema is {lengthPerSegment.Schema.Id}");
            #endregion

            #region Snippet:DtdlParserSample06_DisplayTelemetrySchemaKind
            Console.WriteLine($"lengthPerSegment schema type is {lengthPerSegment.Schema.EntityKind}");
            #endregion

            #region Snippet:DtdlParserSample06_DisplayTelemetryArrayElementSchema
            var lengthPerSegmentSchema = (DTArrayInfo)lengthPerSegment.Schema;
            Console.WriteLine($"array elementSchema is {lengthPerSegmentSchema.ElementSchema.Id}");
            #endregion
        }
    }
}
