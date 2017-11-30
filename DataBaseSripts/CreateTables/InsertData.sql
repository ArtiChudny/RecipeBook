USE RecipeBook

insert into Categories(CategoryName)
values
('Soups'),
('Salads'),
('Desserts'),
('MainCourses');

insert into Recipes(CategoryId,RecipeName,PhotoUrl)
values 
('1','Borsch',null),
('1','Shchi',null),
('2','Greek salad',null),
('3','Pancakes',null),
('4','Cutlets',null)


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
('Carrot')

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

('4','5','200'),
('4','7','0.5'),
('4','8','3'),
('4','4','400'),

('5','4','800'),
('5','5','50'),
('5','8','1'),
('5','9','1')

insert into RecipeDetails (RecipeId,CookingTemperature, CookingTime, RecipeDescription, Steps)
values

('1','100','60 min','Borsch','Steps'),
('2','100','60 min','Shchi','Steps'),
('3','120','20 min','Pancake','Steps'),
('4', null,'20 min','Greek Salad','Steps'),
('5','120','20 min','Cutlets','Steps')

