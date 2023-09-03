﻿using BAYSOFT.Abstractions.Core.Domain.Entities;

namespace Store.Core.Domain.Default.Samples.Entities
{
    public class Sample : DomainEntity<int>
    {
        public string Description { get; set; }
        public Sample()
        {
        }
    }
}