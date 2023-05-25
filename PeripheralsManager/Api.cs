using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PeripheralsManager;

internal class Api
{
    private static readonly HttpClient _client = new HttpClient();
    private static IPAddress _serverIP = new IPAddress(new byte[4] { 127, 0, 0, 1 }); //or mby IPAddress.Loppback
    private static ushort _serverPort = 54321;

    public void DeleteProfile(string profileName)
    {
        
    }


    public void GetServerIP()
    {
        //this method will check a specific file on my website of the actual server's IP
        //that is because the server might change IP occasionally, so I don't wanna hardcode it here

        //should be exetuted when the app starts. 
        //For now, I don't care and the backend will b hosted on localhost.
    }

    public static async void CheckHealth()
    {
        try
        {
            HttpResponseMessage res = await _client.GetAsync($"http://{_serverIP.ToString()}:{_serverPort}/health");
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("api is good");
            }
            else
            {
                MessageBox.Show("nope, api down. Tryign to reach it on:\n" + _serverIP + ":" + _serverPort);
            }

        }
        catch (HttpRequestException ex)
        {
            //TODO: wrap this to an external error thing
            MessageBox.Show("Cannot connect to the API. Please check your internet connection.\n\nIf everything else works, it is error on our end. Please do not hesitate to NOT write us a message about it", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
