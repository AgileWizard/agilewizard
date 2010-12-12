using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AgileWizard.Domain.Entities;
using System.Web.SessionState;
using System.Collections;

namespace AgileWizard.Domain.Repositories
{
    public class StateRepository
    {
        #region const
        public const string KEY_CURRENTUSER = "AgileWizard.Domain.CurrentUser";
        #endregion

        #region Properties
        public static StateRepository Instance
        {
            get { return _instace; }
        } private static StateRepository _instace = new StateRepository();

        public virtual object this[string name]
        {
            get
            {
                return HttpContext.Current.Session[name];
            }
            set
            {
                HttpContext.Current.Session[name] = value;
            }
        }

        public virtual User CurrentUser
        {
            get
            {
                return HttpContext.Current.Session[KEY_CURRENTUSER] as User;
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session[KEY_CURRENTUSER] = value;
                }
            }
        }


        public virtual Boolean IsLoggedIn
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        #endregion

        #region Methods
        public static void Initialize(StateRepository repository)
        {
            _instace = repository;
        }
        #endregion
    }
}
