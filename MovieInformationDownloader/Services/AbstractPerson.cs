using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.Services;

internal abstract class AbstractPerson
{
    public abstract long GetPersonId();
    //public abstract InsertPerson();
    //public abstract UpdatePerson();
    public abstract long Save();
}
