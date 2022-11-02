-- Поскольку связь между продуктами и категориями "многие-ко-многим" то,
-- между ними должна существовать промежуточная таблица, в хранении которой
-- должны находится первичные ключы обоих отношений.
-- Предположим, что такая таблица с наименование product_category существует.
-- Тип первичного ключа (сурогатный или составной) в такой таблице для задачи неважен
Select product.name, category.name
FROM category INNER JOIN product_category ON category.id = product_category.category_id
    RIGHT JOIN product ON product_category.product_id = product.id
