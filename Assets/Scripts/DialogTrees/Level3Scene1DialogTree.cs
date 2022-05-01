using System.Collections.Generic;
using Dialog;

namespace DialogTrees
{
    public class Level3Scene1DialogTree : AbstractDialogTree
    {
        public override int OnDialogOptionPicked(int optionIndex, int dialogLineIndex)
        {
            // Regardless the poem, let the dialog continue
            return 6;
        }

        public override DialogLineInfo GetDialogLine(int dialogLineIndex)
        {
            switch(dialogLineIndex)
            {
                case 0:
                {
                    return new DialogLineInfo("Salutări tinere călător. Bine ai venit la locul meu de veci, domeniul intelectualității eterne unde creativitatea și inteligența umană prosperă în eternitate.", "Eminescu", null);
                }
                case 1:
                {
                    return new DialogLineInfo("... Aolo ăsta e Eminescu... Nici la facultate nu scap de el.", "Tu", null);
                }
                case 2:
                {
                    return new DialogLineInfo("Tinere drag, ce te aduce pe aceste meleaguri? Puțini cutează să se aventureze prin asemenea locuri dezolante fiindu-le frică de dominanța simbolului morții de peste acest spațiu restrâns.", "Eminescu", null);
                }
                case 3:
                {
                    return new DialogLineInfo("Ahm... bună ziua, domnule Eminescu... condoleanțe... Mergeam la facultate, dar nu pot coborî la metrou.", "Tu", null);
                }
                case 4:
                {
                    return new DialogLineInfo("Ah! În drumul tău către cultivarea sinelui intelectual. Apreciez dorința de cunoaștere. Știu de ce ai nevoie în călătoria ta. Dar mai întâi, te voi supune la un test pentru a vedea dacă ești vrednic pentru calea cunoașterii.", "Eminescu", null);
                }
                case 5:
                {
                    var poems = new List<string>
                    {
                        "Luceafărul",
                        "Ce te legeni?",
                        "Dorința",
                        "Scrisoarea III"
                    };

                    return new DialogLineInfo("Alege una din aceste opere celebre scrise de geniul meu pe care să o reciți pentru a-mi demonstra nivelul tău de cultură.", "Eminescu", poems);
                }
                case 6:
                {
                    return new DialogLineInfo("Pff... da' cine mai știe poezia asta...", "Tu", null);
                }
                case 7:
                {
                    return new DialogLineInfo("Și așa... am mai picat pe unu'.", "Eminescu", null);
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}
