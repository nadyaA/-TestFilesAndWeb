using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestFilesAndWeb
{
	class Program
	{
		static string sourceFilePath = @"D:\tmp\testme.txt";

		static void Main(string[] args)
		{
			var i = 0;
			var date = DateTime.Now.AddMinutes(4);
			while (++i > 0 && DateTime.Now <= date)
			{
				DownloadFile(i).Wait();
				UploadFile(i).Wait();
			}
			PrintResult();
		}

		private async static Task DownloadFile(int i)
		{
			using (var h = new HttpClientHandler())
			{
				h.CookieContainer = new CookieContainer();
				var uri = new Uri(@"http://192.168.52.35");
				h.CookieContainer.Add(uri, new Cookie(".ASPXAUTH", "497DD62E46FEDA5B841BB340BBB019A53A39FD9BF3F3E1289707BFDC7B791762C466625813062328549483CA0EE383A357DA236E28F2DB6CA612C63EDDBF9B10205CF6C0D41717A6BB318C82ED7D6EF71B226B55AC527AAC8FBA3CEF65405110ED8FB9DABB21B426029091811C3AD4924BA8A423AB6A9E3DFEAB2C9DA7D26432EFEEB9B68F2DA1700230CB9254631D03A35606154049373BCEA172265B8EDE939888D791A668D584355091EA7E5475C417ACB2C08DAAEE7A5DDB67CD0D72E8B411244F5BA9FE1072D07AD9AEAC1338982F04AA45F93FD4FB2A58A9AA6F4B6A91D571F8984048E740BEB3263FDA7D241081CC3B0EFC3EC1300688A0420557FD4AA3D79DEFF0FC001BAFAC43E8C946BC3D4DFD6EE6DE99FCCBCB9897C2346A44DA9882EE784493151186A3A94533CCEB8F4AA64B7013A61945F2D51C68D27209FDF107E081381E01DEB785123B582D506DD6BFEF1739D3F9DCC54DAB4792F76ED0E8D50A1F30446A524FAA60B26E22624D77149889BA5E5FC2FBCF5997143E285303B1E5046054973CE4E7CC5A6149750E8BE0816E03CDE294172B77930CE7ABFB16CC83360559A4A9C308B3A37E0802507BADBC08E500EC3F79CB6E10500694A062C438D6BB96E38C89BADCF4D766BA815D209F82C3FD95B437AD2AAA77AD77590DE6E5BE5983103E994CCC9ABA06E7F7F8180D3BDB65771CA26B8EAC17E76FA326C5AAC49CBDC8CF0D20AFF42F7D7F3543048C43FE1FE7CC2105CE91685BC97C17C5FD4CE16A885C3386431DDA8AAD37A55C36D6903A2C85937A1D96B03569029F013C5A1E874F5B8094CDA600CA8BCCD3360A49AD91EA9CA4487C8FEB3743EB54B25957C12251E68B4B610F8CA47C4900EA9AFB6F09C2016954ACBAF5AB63D90ABE0D81DF863C108CD46B3B0C2C464BF62F74787DA8180416A697D88104F7CB303D8F91718B03B4ABAB6C3BFD9C2C80949BAFEE6986FDF001D9C0307C0780D3311318BFEF2389F5B0D396C9BEA234059BED8A534B1D56371FCE073C0D2BF257D9D02B46FEB38A61F904F3D5994C9612075093561442F28499AC00BD62FCF29EEB95BCC0D22FA81FFD2971142883967FB999BB27BD45A6FEA195ED5275D618CD901B8AD25812661AB10B177AE4929F92BF045039A3E734FC05BD0A04D3060BF1"));
				h.CookieContainer.Add(uri, new Cookie("sittlrkappshell", "GehqTG%2FJK4KuaHnRLRiORpEXlbLYfdFBPsilATXDTMb7i43009IOfLuSs7nQ8ugGUCGqsnUCZqqeiJIRDTAdbxHWnDMdvQLX%2BprDIN4NLXsx0ArVB21q%2FuXw0%2ByZnWdxUPBrY78vlztqW9YipJ5ErA%3D%3D"));
				h.CookieContainer.Add(uri, new Cookie("__eqtSession", "781478c0-10c1-4fbd-873d-722ea867e2ed.1406190895796"));
				h.CookieContainer.Add(uri, new Cookie("__eqtUser", "054d0497-0f6d-4115-ac8d-df215a06adfe.26"));
				using (var webClient = new HttpClient(h))
				{
					webClient.DefaultRequestHeaders.Add("X-Icenium-SolutionSpace", "34d6a68b-dd2d-4de1-8317-fa5632449e14");
					webClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.125 Safari/537.36");
					webClient.DefaultRequestHeaders.Add("Accept", "application/octet-stream");
					webClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
					webClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate,sdch");
					webClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.8,bg;q=0.6");
					HttpResponseMessage response = await webClient.GetAsync(@"http://192.168.52.35/api/filesystem/raw/bawbaw/bawbaw/testme.txt");
					using (var w = File.AppendText(sourceFilePath))
					{
						w.WriteLine(string.Format("{0}. downloaded at {1} statuscode: {2}", i, DateTime.Now, response.StatusCode));
					}
				}
			}
		}

		private async static Task UploadFile(int i)
		{
			using (var h = new HttpClientHandler())
			{
				h.CookieContainer = new CookieContainer();
				var uri = new Uri(@"http://192.168.52.35");
				h.CookieContainer.Add(uri, new Cookie(".ASPXAUTH", "497DD62E46FEDA5B841BB340BBB019A53A39FD9BF3F3E1289707BFDC7B791762C466625813062328549483CA0EE383A357DA236E28F2DB6CA612C63EDDBF9B10205CF6C0D41717A6BB318C82ED7D6EF71B226B55AC527AAC8FBA3CEF65405110ED8FB9DABB21B426029091811C3AD4924BA8A423AB6A9E3DFEAB2C9DA7D26432EFEEB9B68F2DA1700230CB9254631D03A35606154049373BCEA172265B8EDE939888D791A668D584355091EA7E5475C417ACB2C08DAAEE7A5DDB67CD0D72E8B411244F5BA9FE1072D07AD9AEAC1338982F04AA45F93FD4FB2A58A9AA6F4B6A91D571F8984048E740BEB3263FDA7D241081CC3B0EFC3EC1300688A0420557FD4AA3D79DEFF0FC001BAFAC43E8C946BC3D4DFD6EE6DE99FCCBCB9897C2346A44DA9882EE784493151186A3A94533CCEB8F4AA64B7013A61945F2D51C68D27209FDF107E081381E01DEB785123B582D506DD6BFEF1739D3F9DCC54DAB4792F76ED0E8D50A1F30446A524FAA60B26E22624D77149889BA5E5FC2FBCF5997143E285303B1E5046054973CE4E7CC5A6149750E8BE0816E03CDE294172B77930CE7ABFB16CC83360559A4A9C308B3A37E0802507BADBC08E500EC3F79CB6E10500694A062C438D6BB96E38C89BADCF4D766BA815D209F82C3FD95B437AD2AAA77AD77590DE6E5BE5983103E994CCC9ABA06E7F7F8180D3BDB65771CA26B8EAC17E76FA326C5AAC49CBDC8CF0D20AFF42F7D7F3543048C43FE1FE7CC2105CE91685BC97C17C5FD4CE16A885C3386431DDA8AAD37A55C36D6903A2C85937A1D96B03569029F013C5A1E874F5B8094CDA600CA8BCCD3360A49AD91EA9CA4487C8FEB3743EB54B25957C12251E68B4B610F8CA47C4900EA9AFB6F09C2016954ACBAF5AB63D90ABE0D81DF863C108CD46B3B0C2C464BF62F74787DA8180416A697D88104F7CB303D8F91718B03B4ABAB6C3BFD9C2C80949BAFEE6986FDF001D9C0307C0780D3311318BFEF2389F5B0D396C9BEA234059BED8A534B1D56371FCE073C0D2BF257D9D02B46FEB38A61F904F3D5994C9612075093561442F28499AC00BD62FCF29EEB95BCC0D22FA81FFD2971142883967FB999BB27BD45A6FEA195ED5275D618CD901B8AD25812661AB10B177AE4929F92BF045039A3E734FC05BD0A04D3060BF1"));
				h.CookieContainer.Add(uri, new Cookie("sittlrkappshell", "GehqTG%2FJK4KuaHnRLRiORpEXlbLYfdFBPsilATXDTMb7i43009IOfLuSs7nQ8ugGUCGqsnUCZqqeiJIRDTAdbxHWnDMdvQLX%2BprDIN4NLXsx0ArVB21q%2FuXw0%2ByZnWdxUPBrY78vlztqW9YipJ5ErA%3D%3D"));
				h.CookieContainer.Add(uri, new Cookie("__eqtSession", "781478c0-10c1-4fbd-873d-722ea867e2ed.1406190895796"));
				h.CookieContainer.Add(uri, new Cookie("__eqtUser", "054d0497-0f6d-4115-ac8d-df215a06adfe.26"));
				using (var webClient = new HttpClient(h))
				{
					string webAddress = @"http://192.168.52.35/api/filesystem/bawbaw/bawbaw";
					string destinationFilePath = webAddress + "/testme.txt";
					webClient.DefaultRequestHeaders.Add("X-Icenium-SolutionSpace", "34d6a68b-dd2d-4de1-8317-fa5632449e14");
					webClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.125 Safari/537.36");
					webClient.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8");
					webClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
					webClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate,sdch");
					webClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.8,bg;q=0.6");
					var m = new HttpRequestMessage(HttpMethod.Post, destinationFilePath);
					using (var s = File.Open(sourceFilePath, FileMode.OpenOrCreate))
					{
						m.Content = new StreamContent(s);
						HttpResponseMessage response = await webClient.SendAsync(m);
						using (var w = File.AppendText(sourceFilePath))
						{
							w.WriteLine(string.Format("{0}. uploaded at {1} statuscode: {2}", i, DateTime.Now, response.StatusCode));
						}
					}
				}
			}
		}

		private static void PrintResult()
		{

			var lines = File.ReadAllLines(sourceFilePath);
			var arr = new int[lines.Count()/ 2 + 1];
			foreach (var line in lines)
			{
				var index = line.IndexOf('.');
				if (index > -1)
				{
					var linenumberstr = line.Substring(0, index);
					int linenumber;
					if (int.TryParse(linenumberstr, out linenumber))
					{
						arr[linenumber]++;
					}
				}
			}

			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == 0)
				{
					Console.WriteLine("Both upload and download requests with number {0} have been lost!", i);
				}
				else
				{
					if (arr[i] == 1)
					{
						Console.WriteLine("Some of upload or download requests with number {0} have been lost!", i);
					}
				}
			}

			Console.WriteLine("Test completed. If any requests have been lost they're tracked above this...");
			Console.ReadLine();
		}
	}
}
