using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp16
{
	public class reference
	{

		public async Task PerformTransliteration(string input, string targetLanguage)
		{
			string transliteratedText = await TransliterateText(input, targetLanguage);
			Console.WriteLine("Transliterated Text: " + transliteratedText);
		}

		public async Task<string> TransliterateText(string input, string targetLanguage)
		{
			string apiUrl = $"https://inputtools.google.com/request?text={Uri.EscapeDataString(input)}&ime=transliteration_en_{targetLanguage}&num=1&cp=0&cs=1&ie=utf-8&oe=utf-8&app=demopage";

			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("Referer", "https://www.google.com/");

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseBody = await response.Content.ReadAsStringAsync();

				// Parse the JSON response
				var jsonResult = JsonDocument.Parse(responseBody);
				var root = jsonResult.RootElement;

				if (root.GetArrayLength() >= 2 && root[0].GetString() == "SUCCESS")
				{
					var translations = root[1][0][1];

					foreach (var translation in translations.EnumerateArray())
					{
						var transliteratedText = translation.GetString();
						Console.WriteLine("Transliterated Text: " + transliteratedText);
					}

					// Return the first transliterated text
					return translations[0].GetString();
				}
				else
				{
					Console.WriteLine("Error occurred during transliteration.");
					return string.Empty;
				}
			}
		}

		// ...other methods...
	}
}
