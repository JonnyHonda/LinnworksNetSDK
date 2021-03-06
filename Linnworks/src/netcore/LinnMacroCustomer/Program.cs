﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnMacroCustomer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Guid applicationId;
            Guid secretKey;
            Guid token;


            var context = new LinnworksAPI.ApiContext(new Guid("ddde1007-e273-42e9-b964-3f716ddf0978"), "https://eu-ext.linnworks.net");

            var macro = new LinnworksMacro.LinnworksMacro()
            {
                Api = new LinnworksAPI.ApiObjectManager(context),
                Logger = new LoggerProxy()
            };

            var result = macro.Execute(new Guid("37d8fb79-4eea-401b-911a-d5cb04db61a4"));

            if (result == null)
            {
                Console.WriteLine("Stock item not found");
            }
            else
            {
                Console.WriteLine(result.ItemNumber);
            }
            Console.Read();
        }

        private static LinnworksAPI.BaseSession Authorize(Guid applicationId, Guid secretKey, Guid token)
        {
            var controller = new LinnworksAPI.AuthController(new LinnworksAPI.ApiContext("https://api.linnworks.net"));

            return controller.AuthorizeByApplication(applicationId, secretKey, token);
        }
    }
}
