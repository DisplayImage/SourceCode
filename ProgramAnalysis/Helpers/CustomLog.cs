﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;


namespace ProgramAnalysis.Helpers
{
    public static class CustomLog
    {
        private static object locker = new object();
        public static void LogError(Exception ex)
        {
            lock (locker)
            {
                StringBuilder builder = new StringBuilder();
                builder
                    .AppendLine("----------")
                    .AppendLine(DateTime.Now.ToString())
                    .AppendFormat("Source:\t{0}", ex.Source)
                    .AppendLine()
                    .AppendFormat("Target:\t{0}", ex.TargetSite)
                    .AppendLine()
                    .AppendFormat("Type:\t{0}", ex.GetType().Name)
                    .AppendLine()
                    .AppendFormat("Message:\t{0}", ex.Message)
                    .AppendLine()
                    .AppendFormat("Stack:\t{0}", ex.StackTrace)
                    .AppendLine();

                string filePath = Utility.LogPath + "Log.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.Write(builder.ToString());
                    writer.Flush();
                }
            }
            
        }

        public static void LogError(string ex)
        {
            lock (locker)
            {
                StringBuilder builder = new StringBuilder();
                builder
                    .AppendLine("----------")
                    .AppendLine(DateTime.Now.ToString())
                    .AppendFormat("Message:\t{0}", ex)
                    .AppendLine();

                string filePath = Utility.LogPath + "Log.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.Write(builder.ToString());
                    writer.Flush();
                }
            }
        }

        public static void LogError(string filename, dynamic obj)
        {
            StringBuilder builder = new StringBuilder();
                builder
                    .AppendLine("----------")
                    .AppendLine(DateTime.Now.ToString())
                    .AppendFormat("To email:\t{0}", obj.Email)
                    .AppendLine()
                    .AppendFormat("Username:\t{0}", obj.UserName)
                    .AppendLine()
                    .AppendFormat("Password:\t{0}", obj.Password)
                    .AppendLine()
                    .AppendFormat("ConfirmationToken:\t{0}", obj.ConfirmationToken)
                    .AppendLine();

                string filePath = Utility.LogPath + "Log.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.Write(builder.ToString());
                    writer.Flush();
                }
        }

        public static void LogError(string filename, Exception ex, dynamic obj)
        {
            // You could use any logging approach here

            StringBuilder builder = new StringBuilder();
            builder
                .AppendLine("----------")
                .AppendLine(DateTime.Now.ToString())
                .AppendFormat("Source:\t{0}", ex.Source)
                .AppendLine()
                .AppendFormat("Target:\t{0}", ex.TargetSite)
                .AppendLine()
                .AppendFormat("Type:\t{0}", ex.GetType().Name)
                .AppendLine()
                .AppendFormat("Message:\t{0}", ex.Message)
                .AppendLine()
                .AppendFormat("Stack:\t{0}", ex.StackTrace)
                .AppendLine()
                .AppendFormat("To email:\t{0}", obj.Email)
                .AppendLine()
                .AppendFormat("UserName:\t{0}", obj.UserName)
                .AppendLine()
                .AppendFormat("Password:\t{0}", obj.Password)
                .AppendLine()
                .AppendFormat("ConfirmationToken:\t{0}", obj.ConfirmationToken)
                .AppendLine();

            string filePath = Utility.LogPath + "Log.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(builder.ToString());
                writer.Flush();
            }
        }

        public static void LogError(string filename, Exception ex)
        {
            // You could use any logging approach here

            StringBuilder builder = new StringBuilder();
            builder
                .AppendLine("----------")
                .AppendLine(DateTime.Now.ToString())
                .AppendFormat("Source:\t{0}", ex.Source)
                .AppendLine()
                .AppendFormat("Target:\t{0}", ex.TargetSite)
                .AppendLine()
                .AppendFormat("Type:\t{0}", ex.GetType().Name)
                .AppendLine()
                .AppendFormat("Message:\t{0}", ex.Message)
                .AppendLine()
                .AppendFormat("Stack:\t{0}", ex.StackTrace)
                .AppendLine();

            string filePath = Utility.LogPath + "Log.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(builder.ToString());
                writer.Flush();
            }
        }

        public static void LogError(string filename, string ex)
        {
            // You could use any logging approach here

            StringBuilder builder = new StringBuilder();
            builder
                .AppendLine("----------")
                .AppendLine(DateTime.Now.ToString())
                .AppendFormat("Message:\t{0}", ex)
                .AppendLine();

            string filePath = Utility.LogPath + "Log.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.Write(builder.ToString());
                writer.Flush();
            }
        }
    }
}
