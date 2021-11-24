using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInformationDownloader.Services;

internal abstract class AbstractPerson
{
    public abstract long GetPersonId();
    public abstract void InsertPerson(Person person);
    public abstract void UpdatePerson(Person person);
    public abstract bool Save();
}
