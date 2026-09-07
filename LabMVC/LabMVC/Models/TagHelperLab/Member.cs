namespace LabMVC.Models.TagHelperLab
{
    public class Member
    {
        public string MemberName {  get; set; }
        public string MemberPassword {  get; set; }
        public string Descript {  get; set; }
        public int[] Interest { get; set; }
        public int Married {  get; set; }
        public int City {  get; set; }
 
    }

    public class MemberInterest
    {
        public int id { get; set; }
        public int MemberID { get; set; }
        public int InterestID { get; set; }
    }
    //  id  memberid interestid
    //    1  guest             1
    //    2  guest             2

    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
