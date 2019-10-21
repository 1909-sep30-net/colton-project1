using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.BLogic.Library
{
    public class GuidService
    {
        public Guid Guid { get; } = Guid.NewGuid();
        public DateTime Created { get; } = DateTime.Now;
    }

    // three copies of the class because ASP.NET can't register the same class as a service twice

    public class SingletonGuidService : GuidService
    { }

    public class ScopedGuidService : GuidService
    { }

    public class TransientGuidService : GuidService
    { }
}
