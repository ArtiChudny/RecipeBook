USE RecipeBook

insert into Categories(CategoryName)
values
('Soups'),
('Salads'),
('Desserts'),
('MainCourses');

insert into Recipes(CategoryId,RecipeName,PhotoUrl)
values 
('1','Borsch',''),
('1','Shchi',''),
('2','Greek salad',''),
('3','Pancakes',''),
('4','Cutlets','')


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
('1','1','300'),
('1','2','400'),
('1','3','200'),
('1','4','400'),
('1','6','4'),
('1','9','1'),
('1','10','1'),

('2','1','500'),
('2','3','300'),
('2','4','400'),
('2','6','4'),
('2','9','1'),
('2','10','1'),

('3','10','400g'),
('3','11','400g'),
('3','12','400g'),
('3','13','300g'),
('3','14','100g'),

('4','5','200'),
('4','7','0.5'),
('4','8','3'),

('5','4','800'),
('5','5','50'),
('5','8','1'),
('5','9','1')

insert into RecipeDetails (RecipeId,CookingTemperature, CookingTime, RecipeDescription, Steps)
values

('1','100','60 min','Borsch','Steps'),
('2','100','60 min','Shchi','Steps'),
('3', '','20 min','Greek Salad','Steps'),
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
