﻿using System;

namespace JasmineDotNet
{
    public class SpecWritter
    {
        private readonly IWritter writter;
            
        public SpecWritter(IWritter writter)
        {
            this.writter = writter;
        }

        public void Write(Context context)
        {
            writter.WriteSuite(context.Name);

            foreach (var test in context.Tests)
            {
                throw new NotImplementedException();
            }
        }
    }
}