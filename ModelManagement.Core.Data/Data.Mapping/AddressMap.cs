using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Adderss>
    {
        public AddressMap()
        {
            #region Configuration
            HasKey(t => t.PersonId);
            #endregion

            #region Property
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.City).HasMaxLength(50).HasColumnName("CITY");
            Property(t => t.State).HasMaxLength(50).HasColumnName("STATE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion

            this.ToTable("address");
        }
    }
}
