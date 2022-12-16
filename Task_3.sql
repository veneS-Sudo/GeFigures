-- Поскольку связь между продуктами и категориями "многие-ко-многим" то,
-- между ними должна существовать промежуточная таблица, в хранении которой
-- должны находится первичные ключы обоих отношений.
-- Предположим, что такая таблица с наименование "product_description" существует.
-- Тип первичного ключа (сурогатный или составной) в такой таблице для задачи неважен
select 
      products.name as Product
    , categories.name as Category
from products
    left join
     product_description 
        on products.id = product_description.product_id
    left join 
     categories
        on  = product_description.category_id = categories.id
