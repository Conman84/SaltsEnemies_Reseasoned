using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned
{
    public static class AddCrossModAngels
    {
        public static void Add()
        {
            AddChara("Xet_CH");

            AddEnemy("Nephilim_EN");
            AddEnemy("Seraphim_EN");
            AddEnemy("Ophanim_EN");
            AddEnemy("Metatron_EN");
            AddEnemy("Sachiel_EN");
            AddEnemy("Cherubim_EN");
        }

        public static void AddChara(string chara)
        {
            if (LoadedAssetsHandler.LoadedCharacters.ContainsKey(chara))
            {
                CharacterSO character = LoadedAssetsHandler.GetCharacter(chara);
                if (character.unitTypes == null) character.unitTypes = [];
                character.unitTypes.Add("Angel");
            }
        }
        public static void AddEnemy(string enemy)
        {
            if (LoadedAssetsHandler.LoadedEnemies.ContainsKey(enemy))
            {
                EnemySO character = LoadedAssetsHandler.GetEnemy(enemy);
                if (character.unitTypes == null) character.unitTypes = [];
                character.unitTypes.Add("Angel");
            }
        }
    }
}
