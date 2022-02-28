﻿using System;

namespace Raminagrobis.Work
{
    public class MemberWork
    {
        public int ID { get; private set; }
        public string Company { get; private set; }
        public string Civility { get; private set; }
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}
