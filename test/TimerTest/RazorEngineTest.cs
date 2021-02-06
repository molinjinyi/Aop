using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating; // For extension methods.
using RazorEngine.Text;

namespace TimerTest
{
    class RazorEngineTest
    {
       async static Task Main(string[] args)
        {
            var config = new TemplateServiceConfiguration();
            // .. configure your instance
            config.Language = Language.CSharp; // VB.NET as template language.
            config.EncodedStringFactory = new RawStringFactory(); // Raw string encoding.
            config.EncodedStringFactory = new HtmlEncodedStringFactory(); // Html encoding.
            config.Debug = true;
            var service = RazorEngineService.Create(config);
            Engine.Razor = service;
            // using RazorEngine.Templating; // Dont forget to include this.
            string templateFile = @"C:\Users\CardAppH006\source\repos\Aop\test\TimerTest\Message.cshtml";
            string template = "";
            using (var streamReader = new StreamReader(templateFile)) {
                template = await streamReader.ReadToEndAsync();
                streamReader.Close();
                streamReader.Dispose();
            }
                
            
            var result = "";
            if (!Engine.Razor.IsTemplateCached("templateKey", typeof(Message)) )
            {

                result=Engine.Razor.RunCompile(new LoadedTemplateSource(template, null), "templateKey", typeof(Message), new Message { Name = "World1" });
            }
            else
            {
                result = Engine.Razor.Run("templateKey", typeof(Message), new Message { Name = "World" });
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                result = Engine.Razor.RunCompile(new LoadedTemplateSource(template, null), "templateKey", typeof(Message), new Message { Name = "World1" });
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < 10; i++)
            {
                result = Engine.Razor.Run("templateKey", typeof(Message), new Message { Name = "World2" });
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks);
            Console.WriteLine(result);
        }
    }
    public class Message { 
     public string Name { get; set; }
    }
}


