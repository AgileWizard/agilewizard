﻿using System;
using System.Web;
using AgileWizard.Domain.Users;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Website
{
    public class SessionStateRepository : ISessionStateRepository
    {
        #region const
        public const string KEY_CURRENTUSER = "AgileWizard.Domain.CurrentUser";
        #endregion

        #region Properties
        public static SessionStateRepository Instance
        {
            get { return _instace; }
        } private static SessionStateRepository _instace = new SessionStateRepository();

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
                var currentUser = default(User);
                if (HttpContext.Current != null)
                    currentUser = HttpContext.Current.Session[KEY_CURRENTUSER] as User;

                return currentUser;
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session[KEY_CURRENTUSER] = value;
                }
            }
        }


        public Boolean IsLoggedIn
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        #endregion

        #region Methods
        public static void Initialize(SessionStateRepository repository)
        {
            _instace = repository;
        }
        #endregion
    }
}