using System;
using System.Text;
using CentaDbManageSys.Model;
using CentaLine.Common;

namespace CentaDbManageSys.BLL
{
    public class UserInfo
    {
        public string UserId
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public MemberRole Role
        {
            get;
            set;
        }
        public MemberStatus Status
        {
            get;
            set;
        }
        public DateTime CreateDate
        {
            get;
            set;
        }
        public UserInfo()
        {

        }
        public UserInfo(string cookieStr)
        {
            string[] cookie= cookieStr.Split(new string[] { Seperator.FirstChar }, StringSplitOptions.RemoveEmptyEntries);
            this.UserId = ConvertUtility.Trim(cookie[0]);
            this.UserName = cookie[1];
            this.Role = (MemberRole)Enum.Parse(typeof(MemberRole), cookie[2]);
            this.Status = (MemberStatus)Enum.Parse(typeof(MemberStatus), cookie[3]);
            this.CreateDate = ConvertUtility.ToDateTime(cookie[4]);
        }
        public UserInfo(UserInfoType userInfoType)
        {
            this.UserId = userInfoType.UserInfoId;
            this.UserName = userInfoType.UserName;
            this.Role = (MemberRole)Enum.Parse(typeof(MemberRole), userInfoType.RoleInfoId.ToString());
            this.Status = (MemberStatus)Enum.Parse(typeof(MemberStatus), userInfoType.StatusInfoId.ToString());
            this.CreateDate = userInfoType.CreateDate;
        }
        public void ToCookie()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.UserId);
            builder.Append(Seperator.FirstChar);
            builder.Append(this.UserName);
            builder.Append(Seperator.FirstChar);
            builder.Append(this.Role);
            builder.Append(Seperator.FirstChar);
            builder.Append(this.Status);
            builder.Append(Seperator.FirstChar);
            builder.Append(this.CreateDate);            
            CookieUtility.Set(CookieNames.USERINFO, builder.ToString());
        }
        public void ToSession()
        {
            SessionUtility.Set(SessionNames.USERINFO, this);
        }
    }
}
