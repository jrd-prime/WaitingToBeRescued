namespace _Game._Scripts.Framework.Data.Enums
{
    /// <summary>
    /// Prefixes: Resource 110, Stuff 220, Tool 330, Skill 440, Building 550
    /// </summary>
    public class GameItemTypes
    {
        public enum EResourceItem
        {
            // Resources prefix "110"
            NotSet = 0,
            WoodenStick = 1101,
            CooperOre = 1102,
        }

        public enum EStuffItem
        {
            // Stuff prefix "220"
            NotSet = 0,
            WoodenBox = 2201,
        }

        public enum EToolItem
        {
            // Tools prefix "330"
            NotSet = 0,
            Axe = 3301,
            Pickaxe = 3302,
        }

        public enum ESkillItem
        {
            // Skills prefix "440"
            NotSet = 0,
            Gathering = 4401,
            Mining = 4402,
        }


        public enum EBuildingItem
        {
            // Buildings prefix "550"
            NotSet = 0,
            Shelter = 5501,
        }
    }
}
