﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Mnubo.SmartObjects.Client.Models.Search
{
    public class Row
    {
        /// <summary>
        /// List of values by row
        /// </summary>
        public IImmutableList<object> Values { get; }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="Values">list of values</param>
        public Row(IList<object> values)
        {
            if(values == null)
            {
                values = new List<object>();
            }

            var valuesBuilder = ImmutableList.CreateBuilder<object>();

            foreach (Object value in values)
            {
                valuesBuilder.Add(value);
            }
            Values = valuesBuilder.ToImmutable();
        }
    }
}
