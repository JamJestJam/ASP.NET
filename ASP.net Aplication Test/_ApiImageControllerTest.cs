using ASP.net_Aplication;
using ASP.net_Aplication.Extends;
using ASP.net_Aplication.Models.Image;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ASP.net_Aplication_Test {
    public class _ApiImageControllerTest {
        [Fact]
        public async Task GetPage() {
            using SeleniumServerFactory<Startup> server = new("GetPage");
            using HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync($"{server.BaseAddress}api\\Image\\0");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetImage() {
            using SeleniumServerFactory<Startup> server = new("GetImage");
            using HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync($"{server.BaseAddress}api\\Image\\{StaticData.images[0].ImageID}\\0");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task UpdateImage() {
            using SeleniumServerFactory<Startup> server = new("UpdateImage");
            using HttpClient client = new();

            String json = JsonConvert.SerializeObject(new UpdateModelImage() {
                ImageID = StaticData.images[0].ImageID,
                ImageTitle = "Nowy tytuł"
            });
            StringContent data = new(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Add("Authorization", "Basic YWRtaW46emFxMUBXU1g=");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            HttpResponseMessage resp = await client.PutAsync($"{server.BaseAddress}api\\Image", data);

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

        [Fact]
        public async Task DeleteImage() {
            using SeleniumServerFactory<Startup> server = new("DeleteImage");
            using HttpClient client = new();

            client.DefaultRequestHeaders.Add("Authorization", "Basic YWRtaW46emFxMUBXU1g=");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            HttpResponseMessage resp = await client.DeleteAsync($"{server.BaseAddress}api\\Image\\{StaticData.images[0].ImageID}");

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }

       
    }
}
