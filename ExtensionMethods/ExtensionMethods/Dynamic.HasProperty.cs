﻿using System;

namespace ExtensionMethods
{
    public partial class Dynamic
    {
        private dynamic entity;

        public Dynamic(dynamic entity)
        {
            this.entity = entity;
        }

        public bool HasProperty(string propertyName)
        {
            if (entity == null || propertyName.IsNullOrWhiteSpace())
            {
                return false;
            }
            
            throw new NotImplementedException();
        }
    }
}