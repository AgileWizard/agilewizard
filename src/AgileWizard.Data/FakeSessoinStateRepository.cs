using System.Collections.Generic;
using AgileWizard.Domain.Repositories;
using AgileWizard.Domain.Users;

namespace AgileWizard.Data
{
    public class FakeSessoinStateRepository : ISessionStateRepository
    {

        private Dictionary<string, object> _data = new Dictionary<string, object>();
        public User CurrentUser
        {
            get
            {
                if (_data.ContainsKey("AgileWizard.Domain.CurrentUser"))
                    return _data["AgileWizard.Domain.CurrentUser"] as User;
                return null;
            }
            set 
            {
                _data["AgileWizard.Domain.CurrentUser"] = value;
            }
       }

        public object this[string name]
        {
            get
            {
                return _data[name];
            }
            set
            {
                _data[name] = value;
            }
        }
    }
}
