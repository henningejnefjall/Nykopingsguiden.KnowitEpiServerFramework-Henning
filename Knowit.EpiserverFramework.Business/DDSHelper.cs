using EPiServer.Data;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowit.EpiserverFramework.Business
{
    public class DDSHelper
    {
        [EPiServerDataStore(AutomaticallyRemapStore = true, AutomaticallyCreateStore = true)]
        public class PasswordReset : IDynamicData
        {
            public Identity Id { get; set; }
            public Guid Key { get; set; }
            public DateTime Expires { get; set; }
            public string UserName { get; set; }

            protected void Initialize()
            {
                this.Id = Identity.NewIdentity(Guid.NewGuid());
                this.Key = Guid.NewGuid();
                this.Expires = DateTime.Now.AddDays(7);
                this.UserName = string.Empty;
            }
            public PasswordReset()
            {
                Initialize();
            }

            public PasswordReset(string userName)
            {
                this.UserName = userName;
            }

            /// <summary>
            /// Saves PasswordReset request to Dynamic Data Store
            /// </summary>
            public void Save()
            {
                // Create a data store (but only if one doesn't exist, we won't overwrite an existing one)
                var store = DynamicDataStoreFactory.Instance.CreateStore("passwordreset", typeof(PasswordReset));

                // Save the current PasswordReset request
                store.Save(this);
            }

            /// <summary>
            /// Delete the PasswordReset request permanently
            /// </summary>
            /// <param name="comment"></param>
            public static void Delete(PasswordReset passwordReset)
            {

                // Create a data store (but only if one doesn't exist, we won't overwrite an existing one)
                var store = DynamicDataStoreFactory.Instance.CreateStore("passwordreset", typeof(PasswordReset));

                // Delete the specified comment
                store.Delete(passwordReset.Id);
            }

            public static PasswordReset GetPasswordReset(Guid key)
            {
                // Create a data store (but only if one doesn't exist, we won't overwrite an existing one)
                var store = DynamicDataStoreFactory.Instance.CreateStore("passwordreset", typeof(PasswordReset));

                // Get the PasswordReset request
                var passwordReset = store.Items<PasswordReset>().FirstOrDefault(x => x.Key.Equals(key));

                // Return PasswordReset request as PasswordReset
                return passwordReset;
            }

        }
    }
}