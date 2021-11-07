using BaseLogic.General;
using static BaseLogic.General.DeveloperLevel;

namespace BaseLogic.Developer
{
    public interface IPaidDeveloper : IPaidWorker
    {
        Level ProgramingLevel { get; set; }
    }
}
