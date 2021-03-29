namespace ConstantEvaluation.Buttons
{
    public interface IGenericButton
    {
        string GetButtonName { get; }

        void ButtonClick();
    }
}