using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Entity
{
  public  class Agent_User
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        
        public int ParaentGameID { get; set; }
    }
}
