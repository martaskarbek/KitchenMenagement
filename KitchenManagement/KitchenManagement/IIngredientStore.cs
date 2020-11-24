namespace KitchenManagement
{
    public interface IIngredientStore
    {
        Ingredient? RequestIngredient(Ingredient ingredient);
    }
}