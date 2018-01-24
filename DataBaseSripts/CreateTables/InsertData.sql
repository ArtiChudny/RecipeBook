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

('1','100','60 min','Borsch','1. Boil the pork for at least 1.5 hours, strain the broth through clothing, seperate the meat from the bone and carve it.' +NCHAR(13)+NCHAR(10) +
'2. Peel the raw pork, cut it in thin two-inch strips and stew for half an hour.'+NCHAR(13)+NCHAR(10) +
'3. Add cubed potatoes in the boiling broth. Add the stewed beet when the broth begins to boil again. Add bay leaf.'+ NCHAR(13)+NCHAR(10) +
'4. Cut the carrot the same way as the beet root, fry it all over and add into borsch.' + NCHAR(13)+NCHAR(10) +
'5. Slice the onion, fry on both sides, add tomato paste. Mix everything and fry for some more time.' + NCHAR(13)+NCHAR(10) +
'6. Take the fried onion off the stove and add mashed garlic.' + NCHAR(13)+NCHAR(10) +
'7. Shred the cabbage finely and add (but not much) into borsch when the potato is almost cooked.' + NCHAR(13)+NCHAR(10) +
'8. Cover the saucepan and boil borshch for 5 minutes. Then add fried onion with garlic and seasonings. Mix everything.'),

('2','100','60 min','Shchi','1. Melt butter in medium soup pot or Dutch oven. Add onions and carrots and sauté over medium heat, until golden, 3-5 min. Add potatoes, cabbage, bay leaves, and meet. Cover and simmer 20 minutes.' + NCHAR(13)+NCHAR(10) +
'2. Add the diced tomatoes with any juice and mix well. Taste the soup and season as desired with salt and pepper. Continue to simmer until the tomatoes are heated through, 3-5 minutes.'  + NCHAR(13)+NCHAR(10) +
'3. Serve the soup garnished with dill and sour cream, if desired.'), 
                                                                                     
('3', '-','20 min','Greek Salad','1. In a large salad bowl, combine the  olives, bell peppers, tomatoes, cucumber, olives and cheese.' + NCHAR(13)+NCHAR(10) +
'2. Whisk together the olive oil, lemon juice and black pepper. Pour dressing over salad, toss and serve.'),

('4','120','20 min','Pancake','1. Beat egg until fluffy.' + NCHAR(13)+NCHAR(10) +
'2. Add milk and melted margarine.' + NCHAR(13)+NCHAR(10) +
'3. Add dry ingredients and mix well.' + NCHAR(13)+NCHAR(10) +
'4. Heat a heavy griddle or fry pan which is greased with a little butter on a paper towel.' + NCHAR(13)+NCHAR(10) +
'5. Pour a small amount of batter (approx 1/4 cup) into pan and tip to spread out or spread with spoon.' + NCHAR(13)+NCHAR(10) +
'6. When bubbles appear on surface and begin to break, turn over and cook the other side.'),

('5','120','20 min','Cutlets','1. Grind the onion.' + NCHAR(13)+NCHAR(10) +
'2. Mix the minced meat, egg, salt, pepper, onion.' + NCHAR(13)+NCHAR(10) +
'3. Roll minced meat in flour and form a cutlet.'  + NCHAR(13)+NCHAR(10) +
'4. Put cutlets on a heated frying pan with oil.' + NCHAR(13)+NCHAR(10) +
'5. Fry over medium heat until gold brown.')

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
