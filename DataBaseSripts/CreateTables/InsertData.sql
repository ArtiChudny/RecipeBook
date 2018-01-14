USE RecipeBook

insert into Categories(CategoryName)
values
('Soups'),
('Salads'),
('Desserts'),
('MainCourses');

insert into Recipes(CategoryId,RecipeName,PhotoUrl)
values 
('1','Borsch','/Images/b0b543de.jpg'),
('1','Shchi','/Images/k-2942-00.jpg'),
('2','Greek salad','/Images/grecheskiy_salat.jpg'),
('3','Pancakes','/Images/1a6211b440f113809d52d2a603b77fda.jpg'),
('4','Cutlets','/Images/Kotletyi-iz-telyatinyi.jpg')


insert into Ingredients(IngredientName)
values
('Cabbage'),
('Potato'),
('Beet'),
('Pork'),
('Flour'),
('Water'),
('Milk'),
('Egs'),
('Onion'),
('Tomato'),
('Cucumber'),
('Bell pepper'),
('Sheep cheese'),
('Olives')

insert into RecipesIngredients (RecipeId,IngredientId,Weight)
values
('1','1','300g'),
('1','2','400g'),
('1','3','200g'),
('1','4','400g'),
('1','6','4 pcs'),
('1','9','1 pcs'),
('1','10','1 pcs'),

('2','1','500g'),
('2','3','300g'),
('2','4','400g'),
('2','6','4 pcs'),
('2','9','1 pcs'),
('2','10','1 pcs'),

('3','10','400g'),
('3','11','400g'),
('3','12','400g'),
('3','13','300g'),
('3','14','100g'),

('4','5','200g'),
('4','7','0.5l'),
('4','8','3 pcs'),

('5','4','800g'),
('5','5','50g'),
('5','8','1 pcs'),
('5','9','1 pcs')

insert into RecipeDetails (RecipeId,CookingTemperature, CookingTime, RecipeDescription, Steps)
values

('1','100','60 min','Borsch','Steps'),
('2','100','60 min','Shchi','Steps'),
('3', '-','20 min','Greek Salad','Steps'),
('4','120','20 min','Pancake','Steps'),
('5','120','20 min','Cutlets','Steps')

insert into Roles(RoleName)
values
('Admin'),
('Editor')

insert into Users(Login,Password,Email)
values
('admin','123','cook@gmail.com'),
('editor','123','moder@gmail.com')

insert into UsersRoles(UserId,RoleId)
values
(1, 1),
(1, 2),
(2, 2)
