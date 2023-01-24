﻿using AttributeContent.Implementation;
using AttributeContent.Model;
using Data_To_JSON;
using Data_To_TXT_File;
using static AttributeContent.Implementation.DocumentMethod;

GetDocs();

var txtData = Data;
var documentTexts = Convert.ToString(txtData)!;
const string fileLocation = "C:\\Users\\Chikosolu Akunyili\\RiderProjects\\Data Serialization\\SerializedOutput\\Outputs\\";

const string fileName = "GetDocs.txt";
ConvertToTxtFile.Create_TXT_File(documentTexts, $"{fileLocation}{fileName}");
Console.WriteLine(".txt Created");

const string jsonFileName = "GetDocs.json";
ConvertToJson.SaveAsJsonFormat(DocumentMethod.@CustomData, $"{fileLocation}{jsonFileName}");
Console.WriteLine(".json Created");