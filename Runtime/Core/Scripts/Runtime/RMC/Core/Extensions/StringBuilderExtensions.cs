﻿using System;
using System.Text;

//Keep SHORT namespace so any "RMC" class easily accesses this
namespace RMC.Core.Extensions
{
    /// <summary>
    /// Helper methods for this class
    /// </summary>
    public static class StringBuilderExtensions
    {
        private const string ErrorColor = "#FFcccc";
        
        //  General Methods  --------------------------------------
        
        public static void AppendHeaderLine (this StringBuilder sb, string message)
        {
            // Add one line before it
            sb.AppendLine();
            //sb.AppendLine("<color=\"black\"><b>" + message + "</b></color>");
            sb.AppendLine("<b>" + message + "</b>");
        }
        
        public static void AppendErrorLine (this StringBuilder sb, string message)
        {
            sb.AppendLine($"<color={ErrorColor}><b>" + message + "</b></color>");
        }
        

        
        public static void AppendLines (this StringBuilder sb, int linesToAppend)
        {
            for (int i = 0; i < linesToAppend; i++)
            {
                sb.AppendLine();
            }
        }
        
        public static void AppendBullet (this StringBuilder sb, string message)
        {
            sb.AppendBullet(message, 1);
        }
        
        public static void AppendBullet (this StringBuilder sb, string message, int indentLevels)
        {
            string indentString = "";
            for (int i = 0; i <= indentLevels; i++)
            {
                // Indent just TAB per level to allow for
                // 1. Save the precious horizontal room
                // 2. while still being OBVIOUSLY indented
                indentString += " ";
            }
            
            sb.AppendLine($"{indentString}• {message}");
        }
        
        public static void AppendBulletError (this StringBuilder sb, string message)
        {
            sb.AppendBullet($"<color={ErrorColor}><b>{message}</b></color>");
        }
        
        
        public static void AppendBulletException (this StringBuilder sb, Exception exception)
        {
            sb.AppendBulletError(exception.Message);
        }
    }
}