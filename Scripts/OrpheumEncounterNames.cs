using System;
using System.Collections.Generic;
using System.Text;
using Unity.Collections.LowLevel.Unsafe;

namespace SaltsEnemies_Reseasoned
{
    public static class Orph
    {
        //easymode
        public static class MusicMan
        {
            public static string Easy => "Zone02_MusicMan_Easy_EnemyBundle";
            public static string Med => "Zone02_MusicMan_Medium_EnemyBundle";
        }
        public static class Scrungie
        {
            public static string Hard => "Zone02_Scrungie_Hard_EnemyBundle";
        }
        public static class Jumble
        {
            public static class Blue
            {
                public static string Med => "Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle";
            }
            public static class Purple
            {
                public static string Med => "Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle";
            }
        }
        public static class Spoggle
        {
            public static class Red
            {
                public static string Med => "Zone02_Spoggle_Writhing_Medium_EnemyBundle";
            }
            public static class Purple
            {
                public static string Med => "Zone02_Spoggle_Resonant_Medium_EnemyBundle";
            }
        }
        public static class Revola
        {
            public static string Hard => "Zone02_Revola_Hard_EnemyBundle";
        }

        //hawthorne
        public static class Enigma
        {
            public static string Easy => "Zone02_Enigma_Easy_EnemyBundle";
        }
        public static class Sigil
        {
            public static string Med => "Zone02_Sigil_Medium_EnemyBundle";
        }

        //HARDmode
        public static class H
        {
            public static class MusicMan
            {
                public static string Easy => "H_Zone02_MusicMan_Easy_EnemyBundle";
                public static string Med => "H_Zone02_MusicMan_Medium_EnemyBundle";
            }
            public static class Scrungie
            {
                public static string Med => "H_Zone02_Scrungie_Medium_EnemyBundle";
            }
            public static class Jumble
            {
                public static class Blue
                {
                    public static string Med => "H_Zone02_JumbleGuts_Hollowing_Medium_EnemyBundle";
                }
                public static class Purple
                {
                    public static string Med => "H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle";
                }

                //marmo
                public static class Unstable
                {
                    public static string Easy => "Marmo_Zone02_Digital_JumbleGuts_Easy";
                    public static string Hard => "Marmo_Zone02_Digital_JumbleGuts_Hard";
                }
            }
            public static class Spoggle
            {
                public static class Red
                {
                    public static string Med => "H_Zone02_Spoggle_Writhing_Medium_EnemyBundle";
                }
                public static class Purple
                {
                    public static string Med => "H_Zone02_Spoggle_Resonant_Medium_EnemyBundle";
                }

                //marmo
                public static class Unstable
                {
                    public static string Easy => "Marmo_Zone02_Mechanical_Spoggle_Easy";
                    public static string Hard => "Marmo_Zone02_Mechanical_Spoggle_Hard";
                }
            }
            public static class Maniskin
            {
                public static string Hard => "H_Zone02_InnerChild_Hard_EnemyBundle";
            }
            public static class Sacrifice
            {
                public static string Hard => "H_Zone02_WrigglingSacrifice_Hard_EnemyBundle";
            }
            public static class Revola
            {
                public static string Hard => "H_Zone02_Revola_Hard_EnemyBundle";
            }
            public static class Conductor
            {
                public static string Med => "H_Zone02_Conductor_Medium_EnemyBundle";
                public static string Hard => "H_Zone02_Conductor_Hard_EnemyBundle";
            }

            //hawthorne
            public static class Enigma
            {
                public static string Easy => "H_Zone02_Enigma_Easy_EnemyBundle";
                public static string Med => "H_Zone02_Enigma_Medium_EnemyBundle";
            }
            public static class DeadPixel
            {
                public static string Easy => "H_Zone02_DeadPixel_Easy_EnemyBundle";
            }
            public static class Something
            {
                public static string Easy => "H_Zone02_Something_Easy_EnemyBundle";
                public static string Med => "H_Zone02_Something_Medium_EnemyBundle";
            }
            public static class Crow
            {
                public static string Med => "H_Zone02_Crow_Medium_EnemyBundle";
            }
            public static class Freud
            {
                public static string Med => "H_Zone02_Freud_Medium_EnemyBundle";
            }
            public static class Camera
            {
                public static string Med => "H_Zone02_MechanicalLens_Medium_EnemyBundle";
            }
            public static class Delusion
            {
                public static string Easy => "H_Zone02_Delusion_Easy_EnemyBundle";
                public static string Med => "H_Zone02_Delusion_Medium_EnemyBundle";
            }
            public static class Flower
            {
                public static class Yellow
                {
                    public static string Easy => "H_Zone02_YellowFlower_Easy_EnemyBundle";
                    public static string Med => "H_Zone02_YellowFlower_Medium_EnemyBundle";
                }
                public static class Purple
                {
                    public static string Med => "H_Zone02_PurpleFlower_Medium_EnemyBundle";
                }
            }
            public static class Sigil
            {
                public static string Med => "H_Zone02_Sigil_Medium_EnemyBundle";
            }
            public static class Solvent
            {
                public static string Easy => "H_Zone02_Solvent_Easy_EnemyBundle";
            }
            public static class WindSong
            {
                public static string Med => "H_Zone02_WindSong_Medium_EnemyBundle";
            }
            public static class DeadGod
            {
                public static string Hard => "Salt_DeadGod_Orpheum_Bundle";
            }


            //marmo
            public static class Errant
            {
                public static string Med => "Marmo_Errant_Medium_Bundle";
                public static string Hard => "Marmo_Errant_Hard_Bundle";
            }
        }
    }
}
