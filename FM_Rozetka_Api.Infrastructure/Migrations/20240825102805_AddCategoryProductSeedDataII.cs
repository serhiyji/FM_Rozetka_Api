using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FM_Rozetka_Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryProductSeedDataII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Смартфони, ТВ і Електроніка", 1, "Смартфони, ТВ і Електроніка", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Товари для геймерів", 1, "Товари для геймерів", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Побутова техніка", 1, "Побутова техніка", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Товари для дому", 1, "Товари для дому", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інструменти та автотовари", 1, "Інструменти та автотовари", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Сантехніка та ремонт", 1, "Сантехніка та ремонт", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Дача, сад, город", 1, "Дача, сад, город", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Спорт і захоплення", 1, "Спорт і захоплення", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Одяг, взуття та аксесуари", 1, "Одяг, взуття та аксесуари", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Краса та здоров'я", 1, "Краса та здоров'я", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Товари для дітей", 1, "Товари для дітей", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Зоотовари", 1, "Зоотовари", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Офіс, школа, книги", 1, "Офіс, школа, книги", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Алкогольні напої та продукти", 1, "Алкогольні напої та продукти", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Побутова хімія", 1, "Побутова хімія", null });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ноутбуки", 2, "Ноутбуки", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Планшети", 2, "Планшети", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комп'ютери", 2, "Комп'ютери", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комплектуючi", 2, "Комплектуючi", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Аксесуари для ноутбуків і ПК", 2, "Аксесуари для ноутбуків і ПК", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Серверне обладнання", 2, "Серверне обладнання", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Товари з уцінкою", 2, "Товари з уцінкою", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Офісна техніка", 2, "Офісна техніка", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інтерактивне обладнання", 2, "Інтерактивне обладнання", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мережеве обладнання", 2, "Мережеве обладнання", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Телефони", 2, "Телефони", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Повербанки та зарядні станції", 2, "Повербанки та зарядні станції", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Аксесуари до телефонів", 2, "Аксесуари до телефонів", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Телевізори та аксесуари", 2, "Телевізори та аксесуари", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Фото та відео", 2, "Фото та відео", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові приставки", 2, "Ігрові приставки", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігри", 2, "Ігри", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "PlayStation", 2, "PlayStation", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові приставки Nintendo", 2, "Ігрові приставки Nintendo", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові приставки Xbox", 2, "Ігрові приставки Xbox", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові ноутбуки", 2, "Ігрові ноутбуки", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові монітори", 2, "Ігрові монітори", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комплектуючі для геймерів", 2, "Комплектуючі для геймерів", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрова периферія", 2, "Ігрова периферія", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові маршрутизатори", 2, "Ігрові маршрутизатори", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Атрибутика й сувеніри", 2, "Атрибутика й сувеніри", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Послуги та сервіси для електроніки", 2, "Послуги та сервіси для електроніки", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Велика побутова техніка", 2, "Велика побутова техніка", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Догляд та прибирання", 2, "Догляд та прибирання", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Кліматична техніка", 2, "Кліматична техніка", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Техніка для кухні", 2, "Техніка для кухні", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Дрібна побутова техніка", 2, "Дрібна побутова техніка", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Меблі", 2, "Меблі", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Декор для дому", 2, "Декор для дому", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Системи охорони і безпеки", 2, "Системи охорони і безпеки", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Освітлення", 2, "Освітлення", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Посуд", 2, "Посуд", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інвертар для дому та офісу", 2, "Інвертар для дому та офісу", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Господарські товари", 2, "Господарські товари", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інструменти", 2, "Інструменти", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Витратні матеріали та приладдя", 2, "Витратні матеріали та приладдя", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Обладнання", 2, "Обладнання", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ручний інструмент", 2, "Ручний інструмент", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Елктромонтажне обладнання", 2, "Елктромонтажне обладнання", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Автотовари", 2, "Автотовари", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ванни, бокси, душові", 2, "Ванни, бокси, душові", 7 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мийки, змішувачі, сифони", 2, "Мийки, змішувачі, сифони", 7 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Кераміка", 2, "Кераміка", 7 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інженерна сантехніка", 2, "Інженерна сантехніка", 7 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інсталяції та комплектуючі", 2, "Інсталяції та комплектуючі", 7 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Сушильники для рушників і радіатори", 2, "Сушильники для рушників і радіатори", 7 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інструменти", 2, "Інструменти", 7 });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "Id", "Description", "Level", "Name", "TopId" },
                values: new object[,]
                {
                    { 69, "Ручний інструмент", 2, "Ручний інструмент", 7 },
                    { 70, "Освітлення", 2, "Освітлення", 7 },
                    { 71, "Лічильники", 2, "Лічильники", 7 },
                    { 72, "Меблі для ванної кімнати", 2, "Меблі для ванної кімнати", 7 },
                    { 73, "Тепла підлога", 2, "Тепла підлога", 7 },
                    { 74, "Будівельні матеріали", 2, "Будівельні матеріали", 7 },
                    { 75, "Садова техніка", 2, "Садова техніка", 8 },
                    { 76, "Садовий інвентар", 2, "Садовий інвентар", 8 },
                    { 77, "Системи поливання", 2, "Системи поливання", 8 },
                    { 78, "Садовий інструмент", 2, "Садовий інструмент", 8 },
                    { 79, "Рослини та догляд за ними", 2, "Рослини та догляд за ними", 8 },
                    { 80, "Басейни та аксесуари", 2, "Басейни та аксесуари", 8 },
                    { 81, "Благоустрій території", 2, "Благоустрій території", 8 },
                    { 82, "Садовий декор", 2, "Садовий декор", 8 },
                    { 83, "Снігоприбирання", 2, "Снігоприбирання", 8 },
                    { 84, "Тренажери та спортивне обладнання", 2, "Тренажери та спортивне обладнання", 9 },
                    { 85, "Фітнес та аеробіка", 2, "Фітнес та аеробіка", 9 },
                    { 86, "Спортивні аксесуари", 2, "Спортивні аксесуари", 9 },
                    { 87, "Велосипеди та аксесуари", 2, "Велосипеди та аксесуари", 9 },
                    { 88, "Електротранспорт", 2, "Електротранспорт", 9 },
                    { 89, "Ігрові види спорту", 2, "Ігрові види спорту", 9 },
                    { 90, "Бокс і єдиноборства", 2, "Бокс і єдиноборства", 9 },
                    { 91, "Басейн і аквафітнес", 2, "Басейн і аквафітнес", 9 },
                    { 92, "Товари для відпочинку", 2, "Товари для відпочинку", 9 },
                    { 93, "Квадрокоптери", 2, "Квадрокоптери", 9 },
                    { 94, "Туризм і кемпінг", 2, "Туризм і кемпінг", 9 },
                    { 95, "Риболовля", 2, "Риболовля", 9 },
                    { 96, "Зимові види спорту", 2, "Зимові види спорту", 9 },
                    { 97, "Музичні інструменти", 2, "Музичні інструменти", 9 },
                    { 98, "Одяг для жінок", 2, "Одяг для жінок", 10 },
                    { 99, "Жіноче взуття", 2, "Жіноче взуття", 10 },
                    { 100, "Аксесуари для жінок", 2, "Аксесуари для жінок", 10 },
                    { 101, "Одяг для чоловіків", 2, "Одяг для чоловіків", 10 },
                    { 102, "Чоловіче взуття", 2, "Чоловіче взуття", 10 },
                    { 103, "Аксесуари для чоловіків", 2, "Аксесуари для чоловіків", 10 },
                    { 104, "Дитячий одяг", 2, "Дитячий одяг", 10 },
                    { 105, "Дитяче взуття", 2, "Дитяче взуття", 10 },
                    { 106, "Аксесуари для дітей", 2, "Аксесуари для дітей", 10 },
                    { 107, "Техніка для краси та здоров'я", 2, "Техніка для краси та здоров'я", 11 },
                    { 108, "Косметика і парфюмерія", 2, "Косметика і парфюмерія", 11 },
                    { 109, "Дерматокосметика", 2, "Дерматокосметика", 11 },
                    { 110, "Засоби для гоління", 2, "Засоби для гоління", 11 },
                    { 111, "Засоби контрацепції", 2, "Засоби контрацепції", 11 },
                    { 112, "Особиста гігієна", 2, "Особиста гігієна", 11 },
                    { 113, "Подарунки та сувеніри", 2, "Подарунки та сувеніри", 11 },
                    { 114, "Догляд за обличчям", 2, "Догляд за обличчям", 11 },
                    { 115, "Догляд за тілом", 2, "Догляд за тілом", 11 },
                    { 116, "Догляд за волоссям", 2, "Догляд за волоссям", 11 },
                    { 117, "Парфуми", 2, "Парфуми", 11 },
                    { 118, "Товари медичного призначення", 2, "Товари медичного призначення", 11 },
                    { 119, "Інтимні товари", 2, "Інтимні товари", 11 },
                    { 120, "Фарбування волосся", 2, "Фарбування волосся", 11 },
                    { 121, "Догляд за порожниною рота", 2, "Догляд за порожниною рота", 11 },
                    { 122, "Декоративна косметика", 2, "Декоративна косметика", 11 },
                    { 123, "Аксесуари", 2, "Аксесуари", 11 },
                    { 124, "Косметика для догляду для дітей", 2, "Косметика для догляду для дітей", 11 },
                    { 125, "Іграшки", 2, "Іграшки", 12 },
                    { 126, "Дитяче харчування", 2, "Дитяче харчування", 12 },
                    { 127, "Високотехнологічні іграшки", 2, "Високотехнологічні іграшки", 12 },
                    { 128, "Прогулянки й активний відпочинок", 2, "Прогулянки й активний відпочинок", 12 },
                    { 129, "Гігієна та догляд за дитиною", 2, "Гігієна та догляд за дитиною", 12 },
                    { 130, "Дитячий одяг, взуття та аксесуари", 2, "Дитячий одяг, взуття та аксесуари", 12 },
                    { 131, "Шкільне приладдя", 2, "Шкільне приладдя", 12 },
                    { 132, "Новорічний декор", 2, "Новорічний декор", 12 },
                    { 133, "Дитяча кімната", 2, "Дитяча кімната", 12 },
                    { 134, "Розвиток і творчість", 2, "Розвиток і творчість", 12 },
                    { 135, "Товари для мам", 2, "Товари для мам", 12 },
                    { 136, "Транспорт для всієї родини", 2, "Транспорт для всієї родини", 12 },
                    { 137, "Дитячі книги", 2, "Дитячі книги", 12 },
                    { 138, "Все для кішок", 2, "Товари для кішок", 13 },
                    { 139, "Наповнювачі туалетів для котів", 2, "Наповнювачі туалетів для котів", 13 },
                    { 140, "Товари для птахів", 2, "Товари для птахів", 13 },
                    { 141, "Товари для гризунів", 2, "Товари для гризунів", 13 },
                    { 142, "Все для собак", 2, "Товари для собак", 13 },
                    { 143, "Засоби для боротьби з паразитами", 2, "Засоби від паразитів", 13 },
                    { 144, "Товари для акваріумів", 2, "Акваріуми", 13 },
                    { 145, "Товари для тераріумів і фаунаріумів", 2, "Тераріуми та фаунаріуми", 13 },
                    { 146, "Товари для ставків та водойм", 2, "Стави та водойми", 13 },
                    { 147, "Товари для тваринництва", 2, "Тваринництво", 13 },
                    { 148, "Канцелярські товари", 2, "Канцелярське приладдя", 14 },
                    { 149, "Товари для школи", 2, "Шкільне приладдя", 14 },
                    { 150, "Офісне обладнання", 2, "Офісне приладдя", 14 },
                    { 151, "Декор для новорічних свят", 2, "Новорічний декор", 14 },
                    { 152, "Книги різних жанрів", 2, "Книги", 14 },
                    { 153, "Матеріали для творчості", 2, "Творчість", 14 },
                    { 154, "Сувеніри та подарунки", 2, "Сувенірна продукція", 14 },
                    { 155, "Вино різних видів", 2, "Вино", 15 },
                    { 156, "Лікери, вермути і сиропи", 2, "Лікери, вермути, сиропи", 15 },
                    { 157, "Пиво та сидр", 2, "Пиво та сидр", 15 },
                    { 158, "Сигарети", 2, "Сигарети", 15 },
                    { 159, "Посуд для алкоголю", 2, "Посуд", 15 },
                    { 160, "Міцні алкогольні напої", 2, "Міцні напої", 15 },
                    { 161, "Електронні сигарети та аксесуари", 2, "Електронні сигарети та аксесуари", 15 },
                    { 162, "Продукти харчування", 2, "Продукти", 15 },
                    { 163, "Засоби для прання", 2, "Засоби для прання", 16 },
                    { 164, "Засоби для догляду за будинком", 2, "Засоби для догляду за будинком", 16 },
                    { 165, "Засоби для догляду за ванною та туалетом", 2, "Засоби для догляду за ванною та туалетом", 16 },
                    { 166, "Засоби для миття посуду", 2, "Засоби для миття посуду", 16 },
                    { 167, "Господарські товари", 2, "Господарські товари", 16 },
                    { 168, "Засоби для вуличної зони", 2, "Вулична зона", 16 },
                    { 169, "Екологічні та органічні засоби", 2, "Екологічні та органічні засоби", 16 },
                    { 170, "Asus", 3, "Asus", 17 },
                    { 171, "Lenovo", 3, "Lenovo", 17 },
                    { 172, "Acer", 3, "Acer", 17 },
                    { 173, "HP (Hewlett Packard)", 3, "HP (Hewlett Packard)", 17 },
                    { 174, "Dell", 3, "Dell", 17 },
                    { 175, "Apple Macbook", 3, "Apple Macbook", 17 },
                    { 176, "Apple iPad", 3, "Apple iPad", 18 },
                    { 177, "Samsung", 3, "Samsung", 18 },
                    { 178, "Lenovo", 3, "Lenovo", 18 },
                    { 179, "Xiaomi", 3, "Xiaomi", 18 },
                    { 180, "Чохли для планшетів", 3, "Чохли для планшетів", 18 },
                    { 181, "Захисні плівки та скло", 3, "Захисні плівки та скло", 18 },
                    { 182, "Монітори", 3, "Монітори", 19 },
                    { 183, "Клавіатури та миші", 3, "Клавіатури та миші", 19 },
                    { 184, "Комп'ютерні колонки", 3, "Комп'ютерні колонки", 19 },
                    { 185, "Програмне забезпечення", 3, "Програмне забезпечення", 19 },
                    { 186, "Джерела безперебійного живлення", 3, "Джерела безперебійного живлення", 19 },
                    { 187, "Акумулятори для ДБЖ", 3, "Акумулятори для ДБЖ", 19 },
                    { 188, "Відеокарти", 3, "Відеокарти", 20 },
                    { 189, "SSD", 3, "SSD", 20 },
                    { 190, "Процесори", 3, "Процесори", 20 },
                    { 191, "Жорсткі диски та дискові масиви", 3, "Жорсткі диски та дискові масиви", 20 },
                    { 192, "Оперативна пам'ять", 3, "Оперативна пам'ять", 20 },
                    { 193, "Материнські плати", 3, "Материнські плати", 20 },
                    { 194, "Блоки живлення", 3, "Блоки живлення", 20 },
                    { 195, "Корпуси", 3, "Корпуси", 20 },
                    { 196, "Системи охолодження", 3, "Системи охолодження", 20 },
                    { 197, "Флеш пам'ять USB", 3, "Флеш пам'ять USB", 21 },
                    { 198, "Мережеві фільтри, адаптери та подовжувачі", 3, "Мережеві фільтри, адаптери та подовжувачі", 21 },
                    { 199, "Сумки, рюкзаки та чохли для ноутбуків", 3, "Сумки, рюкзаки та чохли для ноутбуків", 21 },
                    { 200, "Підставки та столики для ноутбуків", 3, "Підставки та столики для ноутбуків", 21 },
                    { 201, "Веб-камери", 3, "Веб-камери", 21 },
                    { 202, "Навушники", 3, "Навушники", 21 },
                    { 203, "Мікрофони", 3, "Мікрофони", 21 },
                    { 204, "Універсальні мобільні батареї для ноутбуків", 3, "Універсальні мобільні батареї для ноутбуків", 21 },
                    { 205, "Кабелі та перехідники", 3, "Кабелі та перехідники", 21 },
                    { 206, "Графічні планшети", 3, "Графічні планшети", 21 },
                    { 207, "БФП/Принтери", 3, "БФП/Принтери", 24 },
                    { 208, "Витратні матеріали", 3, "Витратні матеріали", 24 },
                    { 209, "Шредери", 3, "Шредери", 24 },
                    { 210, "Телефони", 3, "Телефони", 24 },
                    { 211, "Маршрутизатори", 3, "Маршрутизатори", 26 },
                    { 212, "Комутатори", 3, "Комутатори", 26 },
                    { 213, "Мережеві адаптери", 3, "Мережеві адаптери", 26 },
                    { 214, "Ретранслятори Wi-Fi", 3, "Ретранслятори Wi-Fi", 26 },
                    { 215, "Бездротові точки доступу", 3, "Бездротові точки доступу", 26 },
                    { 216, "Мережеві сховища (NAS)", 3, "Мережеві сховища (NAS)", 26 },
                    { 217, "Патч-корди", 3, "Патч-корди", 26 },
                    { 218, "IP-телефонія", 3, "IP-телефонія", 26 },
                    { 219, "Підсилювачі зв'язку", 3, "Підсилювачі зв'язку", 26 },
                    { 220, "Apple", 3, "Apple", 27 },
                    { 221, "Samsung", 3, "Samsung", 27 },
                    { 222, "Xiaomi", 3, "Xiaomi", 27 },
                    { 223, "Motorola", 3, "Motorola", 27 },
                    { 224, "Nokia", 3, "Nokia", 27 },
                    { 225, "Смартфони", 3, "Смартфони", 27 },
                    { 226, "Кнопкові телефони", 3, "Кнопкові телефони", 27 },
                    { 227, "Універсальні мобільні батареї", 3, "Універсальні мобільні батареї", 28 },
                    { 228, "Зарядні станції", 3, "Зарядні станції", 28 },
                    { 229, "Навушники", 3, "Навушники", 29 },
                    { 230, "Кабелі та адаптери", 3, "Кабелі та адаптери", 29 },
                    { 231, "Картки пам'яті", 3, "Картки пам'яті", 29 },
                    { 232, "Чохли для мобільних телефонів", 3, "Чохли для мобільних телефонів", 29 },
                    { 233, "Чохли-книжки", 3, "Чохли-книжки", 29 },
                    { 234, "Бампери", 3, "Бампери", 29 },
                    { 235, "Захисні плівки та скло", 3, "Захисні плівки та скло", 29 },
                    { 236, "Тримачі", 3, "Тримачі", 29 },
                    { 237, "Зарядні пристрої", 3, "Зарядні пристрої", 29 },
                    { 238, "Мобільний інтернет", 3, "Мобільний інтернет", 29 },
                    { 239, "Телевізори", 3, "Телевізори", 30 },
                    { 240, "Samsung", 3, "Samsung", 30 },
                    { 241, "LG", 3, "LG", 30 },
                    { 242, "Xiaomi", 3, "Xiaomi", 30 },
                    { 243, "Підставки, кріплення для ТВ", 3, "Підставки, кріплення для ТВ", 30 },
                    { 244, "Кабелі та адаптери", 3, "Кабелі та адаптери", 30 },
                    { 245, "ТВ-антени та ресивери", 3, "ТВ-антени та ресивери", 30 },
                    { 246, "Універсальні пульти ДК", 3, "Універсальні пульти ДК", 30 },
                    { 247, "ТБ запчастини та обладнання", 3, "ТБ запчастини та обладнання", 30 },
                    { 248, "Фотоапарати", 3, "Фотоапарати", 31 },
                    { 249, "Відеокамери", 3, "Відеокамери", 31 },
                    { 250, "Екшн-камери", 3, "Екшн-камери", 31 },
                    { 251, "Об'єктиви", 3, "Об'єктиви", 31 },
                    { 252, "Аксесуари для фото/відео", 3, "Аксесуари для фото/відео", 31 },
                    { 253, "Зарядні пристрої для фото та відеокамер", 3, "Зарядні пристрої для фото та відеокамер", 31 },
                    { 254, "Акумулятори та батарейки", 3, "Акумулятори та батарейки", 31 },
                    { 255, "Штативи", 3, "Штативи", 31 },
                    { 256, "Студійне обладнання", 3, "Студійне обладнання", 31 },
                    { 257, "Студійне світло", 3, "Студійне світло", 31 },
                    { 258, "Сумки та чохли", 3, "Сумки та чохли", 31 },
                    { 259, "Ігрові приставки PlayStation 5", 3, "Ігрові приставки PlayStation 5", 34 },
                    { 260, "Ігрові приставки PlayStation 4", 3, "Ігрові приставки PlayStation 4", 34 },
                    { 261, "Ігрові приставки PlayStation", 3, "Ігрові приставки PlayStation", 34 },
                    { 262, "Геймпади PlayStation", 3, "Геймпади PlayStation", 34 },
                    { 263, "Шоломи VR PlayStation", 3, "Шоломи VR PlayStation", 34 },
                    { 264, "Гарнітури PlayStation", 3, "Гарнітури PlayStation", 34 },
                    { 265, "Аксесуари PlayStation", 3, "Аксесуари PlayStation", 34 },
                    { 266, "Ігри для PlayStation 5", 3, "Ігри для PlayStation 5", 34 },
                    { 267, "Ігри для PlayStation 4", 3, "Ігри для PlayStation 4", 34 },
                    { 268, "Ігри для Nintendo", 3, "Ігри для Nintendo", 35 },
                    { 269, "Ігри для Xbox", 3, "Ігри для Xbox", 36 },
                    { 270, "Asus", 3, "Asus", 37 },
                    { 271, "HP", 3, "HP", 37 },
                    { 272, "Acer", 3, "Acer", 37 },
                    { 273, "MSI", 3, "MSI", 37 },
                    { 274, "Dell", 3, "Dell", 37 },
                    { 275, "Lenovo", 3, "Lenovo", 37 },
                    { 276, "Ігри для PC", 3, "Ігри для PC", 37 },
                    { 277, "ARTLINE", 3, "ARTLINE", 37 },
                    { 278, "QUBE", 3, "QUBE", 37 },
                    { 279, "Cobra", 3, "Cobra", 37 },
                    { 280, "Samsung", 3, "Samsung", 38 },
                    { 281, "Acer", 3, "Acer", 38 },
                    { 282, "AOC", 3, "AOC", 38 },
                    { 283, "Asus", 3, "Asus", 38 },
                    { 284, "MSI", 3, "MSI", 38 },
                    { 285, "QUBE", 3, "QUBE", 38 },
                    { 286, "Відеокарти", 3, "Відеокарти", 39 },
                    { 287, "Процесори", 3, "Процесори", 39 },
                    { 288, "Оперативна пам'ять", 3, "Оперативна пам'ять", 39 },
                    { 289, "Материнські плати", 3, "Материнські плати", 39 },
                    { 290, "Жорсткі диски", 3, "Жорсткі диски", 39 },
                    { 291, "Блоки живлення", 3, "Блоки живлення", 39 },
                    { 292, "Системи охолодження", 3, "Системи охолодження", 39 },
                    { 293, "Корпуси", 3, "Корпуси", 39 },
                    { 294, "Навушники", 3, "Навушники", 40 },
                    { 295, "Ігрові миші", 3, "Ігрові миші", 40 },
                    { 296, "Ігрові клавіатури", 3, "Ігрові клавіатури", 40 },
                    { 297, "Ігрові коврики", 3, "Ігрові коврики", 40 },
                    { 298, "Маніпулятори, джойстики", 3, "Маніпулятори, джойстики", 40 },
                    { 299, "Геймерські крісла", 3, "Геймерські крісла", 40 },
                    { 300, "Комп'ютерні столи", 3, "Комп'ютерні столи", 40 },
                    { 301, "Геймерські рюкзаки", 3, "Геймерські рюкзаки", 40 },
                    { 302, "Браслети", 3, "Браслети", 42 },
                    { 303, "Брелоки", 3, "Брелоки", 42 },
                    { 304, "Гаманці", 3, "Гаманці", 42 },
                    { 305, "Подушки", 3, "Подушки", 42 },
                    { 306, "Чашки", 3, "Чашки", 42 },
                    { 307, "Фігурки і статуетки", 3, "Фігурки і статуетки", 42 },
                    { 308, "Одяг для геймерів", 3, "Одяг для геймерів", 42 },
                    { 309, "Кепки і головні убори", 3, "Кепки і головні убори", 42 },
                    { 310, "Рюкзаки та сумки", 3, "Рюкзаки та сумки", 42 },
                    { 311, "М'які іграшки", 3, "М'які іграшки", 42 },
                    { 312, "Подарункові набори для геймерів", 3, "Подарункові набори для геймерів", 42 },
                    { 313, "Картинки і постери", 3, "Картинки і постери", 42 },
                    { 314, "Холодильники", 3, "Холодильники", 44 },
                    { 315, "Морозильні камери", 3, "Морозильні камери", 44 },
                    { 316, "Пральні машини", 3, "Пральні машини", 44 },
                    { 317, "Пральні машини із сушаркою", 3, "Пральні машини із сушаркою", 44 },
                    { 318, "Посудомийні машини", 3, "Посудомийні машини", 44 },
                    { 319, "Мікрохвильові печі", 3, "Мікрохвильові печі", 44 },
                    { 320, "Сушильні автомати", 3, "Сушильні автомати", 44 },
                    { 321, "Плити", 3, "Плити", 44 },
                    { 322, "Вбудовувані духові шафи", 3, "Вбудовувані духові шафи", 44 },
                    { 323, "Вбудовувані варильні поверхні", 3, "Вбудовувані варильні поверхні", 44 },
                    { 324, "Комплекти вбудованої техніки", 3, "Комплекти вбудованої техніки", 44 },
                    { 325, "Кухонні витяжки", 3, "Кухонні витяжки", 44 },
                    { 326, "Сертифікати на продовження гарантії", 3, "Сертифікати на продовження гарантії", 44 },
                    { 327, "Встановлення великої побутової техніки", 3, "Встановлення великої побутової техніки", 44 },
                    { 328, "Акумуляторні пилососи", 3, "Акумуляторні пилососи", 45 },
                    { 329, "Роботи-пилососи", 3, "Роботи-пилососи", 45 },
                    { 330, "Пилососи для сухого прибирання", 3, "Пилососи для сухого прибирання", 45 },
                    { 331, "Праски", 3, "Праски", 45 },
                    { 332, "Відпарювачі", 3, "Відпарювачі", 45 },
                    { 333, "Прасувальні системи", 3, "Прасувальні системи", 45 },
                    { 334, "Праски з парогенератором", 3, "Праски з парогенератором", 45 },
                    { 335, "Миючі пилососи", 3, "Миючі пилососи", 45 },
                    { 336, "Пароочисники", 3, "Пароочисники", 45 },
                    { 337, "Швейна техніка та аксесуари", 3, "Швейна техніка та аксесуари", 45 },
                    { 338, "Настінні кондиціонери", 3, "Настінні кондиціонери", 46 },
                    { 339, "Мобільні кондиціонери", 3, "Мобільні кондиціонери", 46 },
                    { 340, "Вентилятори", 3, "Вентилятори", 46 },
                    { 341, "Бойлери", 3, "Бойлери", 46 },
                    { 342, "Очищувачі повітря", 3, "Очищувачі повітря", 46 },
                    { 343, "Зволожувачі повітря", 3, "Зволожувачі повітря", 46 },
                    { 344, "Осушувачі повітря", 3, "Осушувачі повітря", 46 },
                    { 345, "Обігрівачі", 3, "Обігрівачі", 46 },
                    { 346, "Монтаж кондиціонера", 3, "Монтаж кондиціонера", 46 },
                    { 347, "Сертифікати на продовження гарантії", 3, "Сертифікати на продовження гарантії", 46 },
                    { 348, "Кавомашини", 3, "Кавомашини", 47 },
                    { 349, "Мультипечі та аерогрилі", 3, "Мультипечі та аерогрилі", 47 },
                    { 350, "Блендери", 3, "Блендери", 47 },
                    { 351, "Грилі та електрошашличниці", 3, "Грилі та електрошашличниці", 47 },
                    { 352, "Кухонні комбайни", 3, "Кухонні комбайни", 47 },
                    { 353, "Мультиварки", 3, "Мультиварки", 47 },
                    { 354, "Соковичавниці", 3, "Соковичавниці", 47 },
                    { 355, "Електрочайники", 3, "Електрочайники", 47 },
                    { 356, "Електричні печі", 3, "Електричні печі", 47 },
                    { 357, "М'ясорубки", 3, "М'ясорубки", 47 },
                    { 358, "Тостери", 3, "Тостери", 47 },
                    { 359, "Хлібопічки", 3, "Хлібопічки", 47 },
                    { 360, "Міксери", 3, "Міксери", 47 },
                    { 361, "Фільтри-глечики", 3, "Фільтри-глечики", 47 },
                    { 362, "Картриджі для фільтрів глечиків", 3, "Картриджі для фільтрів глечиків", 47 },
                    { 363, "Світ кави", 3, "Світ кави", 47 },
                    { 364, "Вентилятори", 3, "Вентилятори", 48 },
                    { 365, "Пилососи", 3, "Пилососи", 48 },
                    { 366, "Блендери", 3, "Блендери", 48 },
                    { 367, "Кухонні комбайни", 3, "Кухонні комбайни", 48 },
                    { 368, "Електричні зубні щітки", 3, "Електричні зубні щітки", 48 },
                    { 369, "Праски", 3, "Праски", 48 },
                    { 370, "Електричні чайники", 3, "Електрочайники", 48 },
                    { 371, "Сертифікати на продовження гарантії", 3, "Сертифікати на продовження гарантії", 48 },
                    { 372, "Столи з регулюванням по висоті", 3, "Столи з регулюванням по висоті", 49 },
                    { 373, "Комп'ютерні столи", 3, "Комп'ютерні столи", 49 },
                    { 374, "Крісла", 3, "Крісла", 49 },
                    { 375, "Стільці", 3, "Стільці", 49 },
                    { 376, "Обідні столи", 3, "Обідні столи", 49 },
                    { 377, "Кухонні гарнітури", 3, "Кухонні гарнітури", 49 },
                    { 378, "Стелажі та консолі", 3, "Стелажі та консолі", 49 },
                    { 379, "Меблі для спальні", 3, "Меблі для спальні", 49 },
                    { 380, "Безкаркасні меблі", 3, "Безкаркасні меблі", 49 },
                    { 381, "Шафи", 3, "Шафи", 49 },
                    { 382, "Меблі для передпокою і вбиральні", 3, "Меблі для передпокою і вбиральні", 49 },
                    { 383, "Тумби", 3, "Тумби", 49 },
                    { 384, "Полиці", 3, "Полиці", 49 },
                    { 385, "Меблі для саду та дачі", 3, "Меблі для саду та дачі", 49 },
                    { 386, "Комоди", 3, "Комоди", 49 },
                    { 387, "Металеві меблі", 3, "Металеві меблі", 49 },
                    { 388, "Аромати для дому", 3, "Аромати для дому", 50 },
                    { 389, "Підсвічники", 3, "Підсвічники", 50 },
                    { 390, "Настінний декор", 3, "Настінний декор", 50 },
                    { 391, "Вази", 3, "Вази", 50 },
                    { 392, "Інтер'єрні наклейки", 3, "Інтер'єрні наклейки", 50 },
                    { 393, "Ароматерапія", 3, "Ароматерапія", 50 },
                    { 394, "Ікони", 3, "Ікони", 50 },
                    { 395, "Фотоальбоми", 3, "Фотоальбоми", 50 },
                    { 396, "Фоторамки", 3, "Фоторамки", 50 },
                    { 397, "Свічки", 3, "Свічки", 50 },
                    { 398, "Домофони", 3, "Домофони", 51 },
                    { 399, "Комплекти відеоспостереження", 3, "Комплекти відеоспостереження", 51 },
                    { 400, "Комплекти сигналізацій", 3, "Комплекти сигналізацій", 51 },
                    { 401, "Відеодомофони", 3, "Відеодомофони", 51 },
                    { 402, "Стабілізатори напруги", 3, "Стабілізатори напруги", 51 },
                    { 403, "Інвертори", 3, "Інвертори", 51 },
                    { 404, "Люстри", 3, "Люстри", 52 },
                    { 405, "Лампи", 3, "Лампи", 52 },
                    { 406, "Настельні світильники", 3, "Настельні світильники", 52 },
                    { 407, "Точкові світильники", 3, "Точкові світильники", 52 },
                    { 408, "Бра і стельові світильники", 3, "Бра і стельові світильники", 52 },
                    { 409, "Освітлення", 3, "Освітлення", 52 },
                    { 410, "Послуги електрика", 3, "Послуги електрика", 52 },
                    { 411, "Келихи та фужери", 3, "Келихи та фужери", 53 },
                    { 412, "Стопки та чарки", 3, "Стопки та чарки", 53 },
                    { 413, "Сходи", 3, "Сходи", 54 },
                    { 414, "Прасувальні дошки", 3, "Прасувальні дошки", 54 },
                    { 415, "Сушарки для білизни", 3, "Сушарки для білизни", 54 },
                    { 416, "Господарський інвентар", 3, "Господарський інвентар", 54 },
                    { 417, "Брудозахисні покриття", 3, "Брудозахисні покриття", 54 },
                    { 418, "Прання та прасування", 3, "Прання та прасування", 54 },
                    { 419, "Мотузяні вироби", 3, "Мотузяні вироби", 54 },
                    { 420, "Клінінгові обладнання", 3, "Клінінгові обладнання", 54 },
                    { 421, "Сміттєві контейнери", 3, "Сміттєві контейнери", 54 },
                    { 422, "Туалетний папір", 3, "Туалетний папір", 55 },
                    { 423, "Паперові рушники", 3, "Паперові рушники", 55 },
                    { 424, "Серветки", 3, "Серветки", 55 },
                    { 425, "Сміттєві пакети", 3, "Сміттєві пакети", 55 },
                    { 426, "Кухонні губки", 3, "Кухонні губки", 55 },
                    { 427, "Харчова упаковка", 3, "Харчова упаковка", 55 },
                    { 428, "Господарські рукавички", 3, "Господарські рукавички", 55 },
                    { 429, "Серветки для прибирання", 3, "Серветки для прибирання", 55 },
                    { 430, "Одноразовий посуд", 3, "Одноразовий посуд", 55 },
                    { 431, "Гігієнічні накладки на унітаз", 3, "Гігієнічні накладки на унітаз", 55 },
                    { 432, "Шурупокрути та електровикрутки", 3, "Шурупокрути та електровикрутки", 56 },
                    { 433, "Болгарки", 3, "Болгарки", 56 },
                    { 434, "Перфоратори", 3, "Перфоратори", 56 },
                    { 435, "Дрилі та міксери", 3, "Дрилі та міксери", 56 },
                    { 436, "Пили та плиткорізи", 3, "Пили та плиткорізи", 56 },
                    { 437, "Фарбопульти", 3, "Фарбопульти", 56 },
                    { 438, "Електролобзики", 3, "Електролобзики", 56 },
                    { 439, "Вимірювальна техніка", 3, "Вимірювальна техніка", 56 },
                    { 440, "Фрезери", 3, "Фрезери", 56 },
                    { 441, "Багатофункційні інструменти", 3, "Багатофункційні інструменти", 56 },
                    { 442, "Клейові пістолети та аксесуари", 3, "Клейові пістолети та аксесуари", 56 },
                    { 443, "Електрорубанки", 3, "Електрорубанки", 56 },
                    { 444, "Будівельні фени", 3, "Будівельні фени", 56 },
                    { 445, "Свердла", 3, "Свердла", 57 },
                    { 446, "Диски", 3, "Диски", 57 },
                    { 447, "Біти", 3, "Біти", 57 },
                    { 448, "Бури", 3, "Бури", 57 },
                    { 449, "Пиляльні полотна", 3, "Пиляльні полотна", 57 },
                    { 450, "Фрези", 3, "Фрези", 57 },
                    { 451, "Зварювальне обладнання", 3, "Зварювальне обладнання", 58 },
                    { 452, "Генератори", 3, "Генератори", 58 },
                    { 453, "Стабілізатори напруги", 3, "Стабілізатори напруги", 58 },
                    { 454, "Універсальні мийки", 3, "Універсальні мийки", 58 },
                    { 455, "Бетономішалки", 3, "Бетономішалки", 58 },
                    { 456, "Компресори", 3, "Компресори", 58 },
                    { 457, "Теплові гармати", 3, "Теплові гармати", 58 },
                    { 458, "Точильні верстати", 3, "Точильні верстати", 58 },
                    { 459, "Вантажопідіймальне обладнання", 3, "Вантажопідіймальне обладнання", 58 },
                    { 460, "Інвертори", 3, "Інвертори", 58 },
                    { 461, "Промислові пилососи", 3, "Промислові пилососи", 58 },
                    { 462, "Набори інструментів", 3, "Набори інструментів", 59 },
                    { 463, "Скрині та сумки для інструментів", 3, "Скрині та сумки для інструментів", 59 },
                    { 464, "Ключі, знімачі", 3, "Ключі, знімачі", 59 },
                    { 465, "Викрутки", 3, "Викрутки", 59 },
                    { 466, "Вимірювально-розмічальний інструмент", 3, "Вимірювально-розмічальний інструмент", 59 },
                    { 467, "Шарнірно-губцевий інструмент", 3, "Шарнірно-губцевий інструмент", 59 },
                    { 468, "Розетки та вимикачі", 3, "Розетки та вимикачі", 60 },
                    { 469, "Кабельно-провідникова продукція", 3, "Кабельно-провідникова продукція", 60 },
                    { 470, "Автозапчастини", 3, "Автозапчастини", 61 },
                    { 471, "Шини", 3, "Шини", 61 },
                    { 472, "Автомобільні диски", 3, "Автомобільні диски", 61 },
                    { 473, "Відеореєстратори", 3, "Відеореєстратори", 61 },
                    { 474, "Мастила й оливи", 3, "Мастила й оливи", 61 },
                    { 475, "GPS-навігатори", 3, "GPS-навігатори", 61 },
                    { 476, "Автокомпресори", 3, "Автокомпресори", 61 },
                    { 477, "Головні пристрої", 3, "Головні пристрої", 61 },
                    { 478, "Пускозарядні пристрої", 3, "Пускозарядні пристрої", 61 },
                    { 479, "Автоприладдя", 3, "Автоприладдя", 61 },
                    { 480, "Автосигналізації", 3, "Автосигналізації", 61 },
                    { 481, "Техдопомога", 3, "Техдопомога", 61 },
                    { 482, "Домкрати", 3, "Домкрати", 61 },
                    { 483, "Автоакустика", 3, "Автоакустика", 61 },
                    { 484, "Паркувальні системи", 3, "Паркувальні системи", 61 },
                    { 485, "Автохімія", 3, "Автохімія", 61 },
                    { 486, "FM-трансмітери", 3, "FM-трансмітери", 61 },
                    { 487, "Автолампи", 3, "Автолампи", 61 },
                    { 488, "Автокосметика", 3, "Автокосметика", 61 },
                    { 489, "Радар-детектори", 3, "Радар-детектори", 61 },
                    { 490, "Штатні головні пристрої", 3, "Штатні головні пристрої", 61 },
                    { 491, "Дефлектори", 3, "Дефлектори", 61 },
                    { 492, "Автофарби", 3, "Автофарби", 61 },
                    { 493, "Електрообладнання автомобілів", 3, "Електрообладнання автомобілів", 61 },
                    { 494, "Ванни", 3, "Ванни", 62 },
                    { 495, "Гідромасажні бокси", 3, "Гідромасажні бокси", 62 },
                    { 496, "Душові гарнітури", 3, "Душові гарнітури", 62 },
                    { 497, "Душові кабіни та стінки", 3, "Душові кабіни та стінки", 62 },
                    { 498, "Бойлери", 3, "Бойлери", 62 },
                    { 499, "Панелі для ванн", 3, "Панелі для ванн", 62 },
                    { 500, "Душові двері та перегородки", 3, "Душові двері та перегородки", 62 },
                    { 501, "Змішувачі", 3, "Змішувачі", 63 },
                    { 502, "Кухонні мийки", 3, "Кухонні мийки", 63 },
                    { 503, "Кухонні змішувачі", 3, "Кухонні змішувачі", 63 },
                    { 504, "Сифони", 3, "Сифони", 63 },
                    { 505, "Системи зворотного осмосу", 3, "Системи зворотного осмосу", 63 },
                    { 506, "Унітази", 3, "Унітази", 64 },
                    { 507, "Раковини", 3, "Раковини", 64 },
                    { 508, "Сушарки для рук", 3, "Сушарки для рук", 64 },
                    { 509, "Біде", 3, "Біде", 64 },
                    { 510, "Бачки для унітазу", 3, "Бачки для унітазу", 64 },
                    { 511, "Паперотримачі та полички", 3, "Паперотримачі та полички", 64 },
                    { 512, "Інсталяції для унітазу", 3, "Інсталяції для унітазу", 66 },
                    { 513, "Інсталяції для біде", 3, "Інсталяції для біде", 66 },
                    { 514, "Кнопки для змиву", 3, "Кнопки для змиву", 66 },
                    { 515, "Сушильники для рушників", 3, "Сушильники для рушників", 67 },
                    { 516, "Радіатори", 3, "Радіатори", 67 },
                    { 517, "Болгарки", 3, "Болгарки", 68 },
                    { 518, "Перфоратори", 3, "Перфоратори", 68 },
                    { 519, "Витратні матеріали та приладдя", 3, "Витратні матеріали та приладдя", 68 },
                    { 520, "Обладнання", 3, "Обладнання", 68 },
                    { 521, "Генератори", 3, "Генератори", 68 },
                    { 522, "Зварювальне обладнання", 3, "Зварювальне обладнання", 68 },
                    { 523, "Промислові пилососи", 3, "Промислові пилососи", 68 },
                    { 524, "Набори інструментів", 3, "Набори інструментів", 69 },
                    { 525, "Ключі, знімачі", 3, "Ключі, знімачі", 69 },
                    { 526, "Скрині та сумки для інструментів", 3, "Скрині та сумки для інструментів", 69 },
                    { 527, "Люстри", 3, "Люстри", 70 },
                    { 528, "Настінно-стельові світильники", 3, "Настінно-стельові світильники", 70 },
                    { 529, "Точкові світильники", 3, "Точкові світильники", 70 },
                    { 530, "Бра та настінні світильники", 3, "Бра та настінні світильники", 70 },
                    { 531, "Настільні лампи", 3, "Настільні лампи", 70 },
                    { 532, "Торшери", 3, "Торшери", 70 },
                    { 533, "Світильники для ванної", 3, "Світильники для ванної", 70 },
                    { 534, "Дитячі настільні лампи", 3, "Дитячі настільні лампи", 70 },
                    { 535, "Вуличне освітлення", 3, "Вуличне освітлення", 70 },
                    { 536, "Лампочки та аксесуари", 3, "Лампочки та аксесуари", 70 },
                    { 537, "Офісно-промислове освітлення", 3, "Офісно-промислове освітлення", 70 },
                    { 538, "Захист від перепадів напруги", 3, "Захист від перепадів напруги", 71 },
                    { 539, "Лічильники води", 3, "Лічильники води", 71 },
                    { 540, "Лічильники газу", 3, "Лічильники газу", 71 },
                    { 541, "Лічильники електроенергії", 3, "Лічильники електроенергії", 71 },
                    { 542, "Тумби", 3, "Тумби", 72 },
                    { 543, "Дзеркала", 3, "Дзеркала", 72 },
                    { 544, "Пенали", 3, "Пенали", 72 },
                    { 545, "Покрівля та водостік", 3, "Покрівля та водостік", 74 },
                    { 546, "Газонокосарки", 3, "Газонокосарки", 75 },
                    { 547, "Тримери та мотокоси", 3, "Тримери та мотокоси", 75 },
                    { 548, "Електрокультиватори", 3, "Електрокультиватори", 75 },
                    { 549, "Кущорізи", 3, "Кущорізи", 75 },
                    { 550, "Мотокультиватори", 3, "Мотокультиватори", 75 },
                    { 551, "Акумуляторні пилки", 3, "Акумуляторні пилки", 75 },
                    { 552, "Електропили", 3, "Електропили", 75 },
                    { 553, "Садові подрібнювачі та дровоколи", 3, "Садові подрібнювачі та дровоколи", 75 },
                    { 554, "Бензопили", 3, "Бензопили", 75 },
                    { 555, "Повітродуви", 3, "Повітродуви", 75 },
                    { 556, "Витратні матеріали для мотокос", 3, "Витратні матеріали для мотокос", 75 },
                    { 557, "Мотоблоки", 3, "Мотоблоки", 75 },
                    { 558, "Аератори", 3, "Аератори", 75 },
                    { 559, "Обприскувачі", 3, "Обприскувачі", 76 },
                    { 560, "Тачки", 3, "Тачки", 76 },
                    { 561, "Сітки садові", 3, "Сітки садові", 76 },
                    { 562, "Агроволокно", 3, "Агроволокно", 76 },
                    { 563, "Садові огорожі", 3, "Садові огорожі", 76 },
                    { 564, "Компостери садові", 3, "Компостери садові", 76 },
                    { 565, "Пластикові ємності", 3, "Пластикові ємності", 76 },
                    { 566, "Теплиці", 3, "Теплиці", 76 },
                    { 567, "Лійки для квітів", 3, "Лійки для квітів", 76 },
                    { 568, "Садове приладдя", 3, "Садове приладдя", 76 },
                    { 569, "Драбини, підмостки", 3, "Драбини, підмостки", 76 },
                    { 570, "Шланги", 3, "Шланги", 77 },
                    { 571, "Занурювальні насоси", 3, "Занурювальні насоси", 77 },
                    { 572, "Насадки", 3, "Насадки", 77 },
                    { 573, "Зрошувачі", 3, "Зрошувачі", 77 },
                    { 574, "Поверхневі насоси", 3, "Поверхневі насоси", 77 },
                    { 575, "Комплектуючі до насосів", 3, "Комплектуючі до насосів", 77 },
                    { 576, "Набори для крапельного поливу", 3, "Набори для крапельного поливу", 77 },
                    { 577, "Комплектуючі для поливу", 3, "Комплектуючі для поливу", 77 },
                    { 578, "Таймери для поливу", 3, "Таймери для поливу", 77 },
                    { 579, "Мотопомпи", 3, "Мотопомпи", 77 },
                    { 580, "Циркуляційні насоси", 3, "Циркуляційні насоси", 77 },
                    { 581, "Секатори", 3, "Секатори", 78 },
                    { 582, "Лопати", 3, "Лопати", 78 },
                    { 583, "Сокири", 3, "Сокири", 78 },
                    { 584, "Сучкорізи", 3, "Сучкорізи", 78 },
                    { 585, "Ручні культиватори", 3, "Ручні культиватори", 78 },
                    { 586, "Садові ножиці", 3, "Садові ножиці", 78 },
                    { 587, "Граблі", 3, "Граблі", 78 },
                    { 588, "Пили садові", 3, "Пили садові", 78 },
                    { 589, "Сапи", 3, "Сапи", 78 },
                    { 590, "Садові совки", 3, "Садові совки", 78 },
                    { 591, "Держаки для садового інструменту", 3, "Держаки для садового інструменту", 78 },
                    { 592, "Набори садових інструментів", 3, "Набори садових інструментів", 78 },
                    { 593, "Садові ножі", 3, "Садові ножі", 78 },
                    { 594, "Насіння газонних трав", 3, "Насіння газонних трав", 79 },
                    { 595, "Органічні добрива", 3, "Органічні добрива", 79 },
                    { 596, "Мінеральні добрива", 3, "Мінеральні добрива", 79 },
                    { 597, "Вазони", 3, "Вазони", 79 },
                    { 598, "Отрута для гризунів", 3, "Отрута для гризунів", 79 },
                    { 599, "Субстрати та ґрунти для рослин", 3, "Субстрати та ґрунти для рослин", 79 },
                    { 600, "Пастки для гризунів та птахів", 3, "Пастки для гризунів та птахів", 79 },
                    { 601, "Інсектициди", 3, "Інсектициди", 79 },
                    { 602, "Фунгіциди", 3, "Фунгіциди", 79 },
                    { 603, "Органомінеральні добрива", 3, "Органомінеральні добрива", 79 },
                    { 604, "Стимулятори росту рослин", 3, "Стимулятори росту рослин", 79 },
                    { 605, "Біодобрива", 3, "Біодобрива", 79 },
                    { 606, "Насіння пряних та зелених трав", 3, "Насіння пряних та зелених трав", 79 },
                    { 607, "Басейни", 3, "Басейни", 80 },
                    { 608, "Аксесуари для басейнів", 3, "Аксесуари для басейнів", 80 },
                    { 609, "Обладнання для басейнів", 3, "Обладнання для басейнів", 80 },
                    { 610, "Сміттєві контейнери", 3, "Сміттєві контейнери", 81 },
                    { 611, "Вуличні урни", 3, "Вуличні урни", 81 },
                    { 612, "Бігові доріжки", 3, "Бігові доріжки", 84 },
                    { 613, "Гантелі, диски, грифи, замки", 3, "Гантелі, диски, грифи, замки", 84 },
                    { 614, "Велотренажери", 3, "Велотренажери", 84 },
                    { 615, "Орбітреки", 3, "Орбітреки", 84 },
                    { 616, "Батути й аксесуари", 3, "Батути й аксесуари", 84 },
                    { 617, "Силові тренажери", 3, "Силові тренажери", 84 },
                    { 618, "Шведські стінки та турніки", 3, "Шведські стінки та турніки", 84 },
                    { 619, "Йога", 3, "Йога", 85 },
                    { 620, "Еспандери", 3, "Еспандери", 85 },
                    { 621, "Фітнес м'ячі", 3, "Фітнес м'ячі", 85 },
                    { 622, "Пояси та рукавички для фітнесу", 3, "Пояси та рукавички для фітнесу", 85 },
                    { 623, "Скакалки", 3, "Скакалки", 85 },
                    { 624, "Аксесуари для спортивного харчування", 3, "Аксесуари для спортивного харчування", 86 },
                    { 625, "Велосипеди", 3, "Велосипеди", 87 },
                    { 626, "Велоаксесуари", 3, "Велоаксесуари", 87 },
                    { 627, "Велогума", 3, "Велогума", 87 },
                    { 628, "Велозапчастини", 3, "Велозапчастини", 87 },
                    { 629, "Електросамокати", 3, "Електросамокати", 88 },
                    { 630, "Електроскутери", 3, "Електроскутери", 88 },
                    { 631, "Електровелосипеди", 3, "Електровелосипеди", 88 },
                    { 632, "М'ячі", 3, "М'ячі", 89 },
                    { 633, "Настільний теніс", 3, "Настільний теніс", 89 },
                    { 634, "Бадмінтон, спідмінтон, сквош", 3, "Бадмінтон, спідмінтон, сквош", 89 },
                    { 635, "Рукавиці для боксу", 3, "Рукавиці для боксу", 90 },
                    { 636, "Боксерські мішки та груші", 3, "Боксерські мішки та груші", 90 },
                    { 637, "Окуляри для плавання", 3, "Окуляри для плавання", 91 },
                    { 638, "Шапочки для плавання", 3, "Шапочки для плавання", 91 },
                    { 639, "Мультиінструменти, точилки", 3, "Мультиінструменти, точилки", 92 },
                    { 640, "Рації", 3, "Рації", 92 },
                    { 641, "Біноклі", 3, "Біноклі", 92 },
                    { 642, "Складані меблі", 3, "Складані меблі", 94 },
                    { 643, "Намети й аксесуари", 3, "Намети й аксесуари", 94 },
                    { 644, "Спальники", 3, "Спальники", 94 },
                    { 645, "Туристичні килимки", 3, "Туристичні килимки", 94 },
                    { 646, "Надувні меблі й аксесуари", 3, "Надувні меблі й аксесуари", 94 },
                    { 647, "Мангали, барбекю, гриль", 3, "Мангали, барбекю, гриль", 94 },
                    { 648, "Аксесуари для мангалів", 3, "Аксесуари для мангалів", 94 },
                    { 649, "Ліхтарі й аксесуари", 3, "Ліхтарі й аксесуари", 94 },
                    { 650, "Газові балони і комплектуючі", 3, "Газові балони і комплектуючі", 94 },
                    { 651, "Туристичні пальники", 3, "Туристичні пальники", 94 },
                    { 652, "Вудилища", 3, "Вудилища", 95 },
                    { 653, "Котушки рибальські", 3, "Котушки рибальські", 95 },
                    { 654, "Човни й аксесуари", 3, "Човни й аксесуари", 95 },
                    { 655, "Ящики та сумки", 3, "Ящики та сумки", 95 },
                    { 656, "Клавішні інструменти", 3, "Клавішні інструменти", 97 },
                    { 657, "Гітари та обладнання", 3, "Гітари та обладнання", 97 },
                    { 658, "Мікрофони", 3, "Мікрофони", 97 },
                    { 659, "Музичні інструменти для дітей", 3, "Музичні інструменти для дітей", 97 },
                    { 660, "Плаття", 3, "Плаття", 98 },
                    { 661, "Футболки", 3, "Футболки", 98 },
                    { 662, "Джинси", 3, "Джинси", 98 },
                    { 663, "Спортивні костюми", 3, "Спортивні костюми", 98 },
                    { 664, "Худі, світшоти", 3, "Худі, світшоти", 98 },
                    { 665, "Піджаки та жакети", 3, "Піджаки та жакети", 98 },
                    { 666, "Сорочки та блузи", 3, "Сорочки та блузи", 98 },
                    { 667, "Купальники", 3, "Купальники", 98 },
                    { 668, "Спідня білизна", 3, "Спідня білизна", 98 },
                    { 669, "Нічний і домашній одяг", 3, "Нічний і домашній одяг", 98 },
                    { 670, "Босоніжки", 3, "Босоніжки", 99 },
                    { 671, "Сандалі", 3, "Сандалі", 99 },
                    { 672, "Кеди", 3, "Кеди", 99 },
                    { 673, "Кросівки", 3, "Кросівки", 99 },
                    { 674, "Шльопанці та крокси", 3, "Шльопанці та крокси", 99 },
                    { 675, "Туфлі та балетки", 3, "Туфлі та балетки", 99 },
                    { 676, "Кімнатне взуття", 3, "Кімнатне взуття", 99 },
                    { 677, "Сумки та рюкзаки", 3, "Сумки та рюкзаки", 100 },
                    { 678, "Головні убори", 3, "Головні убори", 100 },
                    { 679, "Сонцезахисні окуляри", 3, "Сонцезахисні окуляри", 100 },
                    { 680, "Гаманці", 3, "Гаманці", 100 },
                    { 681, "Парасолі", 3, "Парасолі", 100 },
                    { 682, "Футболки", 3, "Футболки", 101 },
                    { 683, "Спортивні костюми", 3, "Спортивні костюми", 101 },
                    { 684, "Спортивні штани", 3, "Спортивні штани", 101 },
                    { 685, "Худі та толстовки", 3, "Худі та толстовки", 101 },
                    { 686, "Шорти", 3, "Шорти", 101 },
                    { 687, "Джинси", 3, "Джинси", 101 },
                    { 688, "Сорочки", 3, "Сорочки", 101 },
                    { 689, "Нічний і домашній одяг", 3, "Нічний і домашній одяг", 101 },
                    { 690, "Спідня білизна", 3, "Спідня білизна", 101 },
                    { 691, "Шкарпетки", 3, "Шкарпетки", 101 },
                    { 692, "Сандалії", 3, "Сандалії", 102 },
                    { 693, "Кеди", 3, "Кеди", 102 },
                    { 694, "Кросівки", 3, "Кросівки", 102 },
                    { 695, "Туфлі", 3, "Туфлі", 102 },
                    { 696, "Мокасини", 3, "Мокасини", 102 },
                    { 697, "Шльопанці та крокси", 3, "Шльопанці та крокси", 102 },
                    { 698, "Кімнатне взуття", 3, "Кімнатне взуття", 102 },
                    { 699, "Рюкзаки та сумки", 3, "Рюкзаки та сумки", 103 },
                    { 700, "Головні убори", 3, "Головні убори", 103 },
                    { 701, "Сонцезахисні окуляри", 3, "Сонцезахисні окуляри", 103 },
                    { 702, "Ремені", 3, "Ремені", 103 },
                    { 703, "Парасолі", 3, "Парасолі", 103 },
                    { 704, "Футболки та сорочки для хлопчиків", 3, "Футболки та сорочки для хлопчиків", 104 },
                    { 705, "Шорти, джинси, брюки для хлопчиків", 3, "Шорти, джинси, брюки для хлопчиків", 104 },
                    { 706, "Спортивні костюми для хлопчиків", 3, "Спортивні костюми для хлопчиків", 104 },
                    { 707, "Худі та світшоти для хлопчиків", 3, "Худі та світшоти для хлопчиків", 104 },
                    { 708, "Дитячий верхній одяг", 3, "Дитячий верхній одяг", 104 },
                    { 709, "Плаття та сарафани для дівчаток", 3, "Плаття та сарафани для дівчаток", 104 },
                    { 710, "Шорти та штани для дівчаток", 3, "Шорти та штани для дівчаток", 104 },
                    { 711, "Худі, світшоти для дівчаток", 3, "Худі, світшоти для дівчаток", 104 },
                    { 712, "Спортивні костюми для дівчаток", 3, "Спортивні костюми для дівчаток", 104 },
                    { 713, "Дитяча нижня білизна", 3, "Дитяча нижня білизна", 104 },
                    { 714, "Кросівки та кеди для хлопчиків", 3, "Кросівки та кеди для хлопчиків", 105 },
                    { 715, "Шльопанці для хлопчиків", 3, "Шльопанці для хлопчиків", 105 },
                    { 716, "Сандалії для хлопчиків", 3, "Сандалії для хлопчиків", 105 },
                    { 717, "Туфлі для хлопчиків", 3, "Туфлі для хлопчиків", 105 },
                    { 718, "Кросівки для дівчаток", 3, "Кросівки для дівчаток", 105 },
                    { 719, "Туфлі для дівчаток", 3, "Туфлі для дівчаток", 105 },
                    { 720, "Шльопанці для дівчаток", 3, "Шльопанці для дівчаток", 105 },
                    { 721, "Сандалії для дівчаток", 3, "Сандалії для дівчаток", 105 },
                    { 722, "Машинки для стриження", 3, "Машинки для стриження", 107 },
                    { 723, "Триммери", 3, "Триммери", 107 },
                    { 724, "Електробритви", 3, "Електробритви", 107 },
                    { 725, "Фени", 3, "Фени", 107 },
                    { 726, "Епілятори", 3, "Епілятори", 107 },
                    { 727, "Подарункові набори", 3, "Подарункові набори", 107 },
                    { 728, "Станок для гоління", 3, "Станок для гоління", 110 },
                    { 729, "Лезо для бритви", 3, "Лезо для бритви", 110 },
                    { 730, "Косметика для гоління", 3, "Косметика для гоління", 110 },
                    { 731, "Туалетний папір", 3, "Туалетний папір", 112 },
                    { 732, "Підгузки для дорослих", 3, "Підгузки для дорослих", 112 },
                    { 733, "Вологі серветки", 3, "Вологі серветки", 112 },
                    { 734, "Крем", 3, "Крем", 114 },
                    { 735, "Маска для обличчя", 3, "Маска для обличчя", 114 },
                    { 736, "Міцелярна вода", 3, "Міцелярна вода", 114 },
                    { 737, "Засіб для вмивання", 3, "Засіб для вмивання", 114 },
                    { 738, "Патчі", 3, "Патчі", 114 },
                    { 739, "Дезодоранти і антиперспіранти", 3, "Дезодоранти і антиперспіранти", 115 },
                    { 740, "Засоби для інтимної гігієни", 3, "Засоби для інтимної гігієни", 115 },
                    { 741, "Догляд за руками", 3, "Догляд за руками", 115 },
                    { 742, "Ефірні масла", 3, "Ефірні масла", 115 },
                    { 743, "Шампуні", 3, "Шампуні", 116 },
                    { 744, "Олія для волосся", 3, "Олія для волосся", 116 },
                    { 745, "Кондиціонери", 3, "Кондиціонери", 116 },
                    { 746, "Набори по догляду за волоссям", 3, "Набори по догляду за волоссям", 116 },
                    { 747, "Маски для волосся", 3, "Маски для волосся", 116 },
                    { 748, "Чоловіча парфумерія", 3, "Чоловіча парфумерія", 117 },
                    { 749, "Жіноча парфумерія", 3, "Жіноча парфумерія", 117 },
                    { 750, "Аромати для дому", 3, "Аромати для дому", 117 },
                    { 751, "Фарба для волосся", 3, "Фарба для волосся", 120 },
                    { 752, "Тонуючі засоби", 3, "Тонуючі засоби", 120 },
                    { 753, "Зубна паста", 3, "Зубна паста", 121 },
                    { 754, "Зубні щітки", 3, "Зубні щітки", 121 },
                    { 755, "Електричні зубні щітки і іррігатори", 3, "Електричні зубні щітки і іррігатори", 121 },
                    { 756, "Лак для нігтів", 3, "Лак для нігтів", 122 },
                    { 757, "Гель-лак", 3, "Гель-лак", 122 },
                    { 758, "Губна помада", 3, "Губна помада", 122 },
                    { 759, "Блиск для губ", 3, "Блиск для губ", 122 },
                    { 760, "Туш для вій", 3, "Туш для вій", 122 },
                    { 761, "Тіні для вій", 3, "Тіні для вій", 122 },
                    { 762, "Олівці для очей", 3, "Олівці для очей", 122 },
                    { 763, "Тональні засоби", 3, "Тональні засоби", 122 },
                    { 764, "Пудра", 3, "Пудра", 122 },
                    { 765, "Для манікюру", 3, "Для манікюру", 123 },
                    { 766, "Для макіяжу", 3, "Для макіяжу", 123 },
                    { 767, "Для волосся", 3, "Для волосся", 123 },
                    { 768, "Підгузки", 3, "Підгузки", 124 },
                    { 769, "Косметика для дітей", 3, "Косметика для дітей", 124 },
                    { 770, "Засоби для купання", 3, "Засоби для купання", 124 },
                    { 771, "Дитячі конструктори", 3, "Дитячі конструктори", 125 },
                    { 772, "Інтерактивні іграшки", 3, "Інтерактивні іграшки", 125 },
                    { 773, "Настільні ігри", 3, "Настільні ігри", 125 },
                    { 774, "Творчість", 3, "Творчість", 125 },
                    { 775, "Ігрові набори", 3, "Ігрові набори", 125 },
                    { 776, "Радіокеровані іграшки", 3, "Радіокеровані іграшки", 125 },
                    { 777, "Ляльки", 3, "Ляльки", 125 },
                    { 778, "Іграшки для малюків", 3, "Іграшки для малюків", 125 },
                    { 779, "М'які іграшки", 3, "М'які іграшки", 125 },
                    { 780, "Іграшкові машинки та техніка", 3, "Іграшкові машинки та техніка", 125 },
                    { 781, "Іграшкова зброя", 3, "Іграшкова зброя", 125 },
                    { 782, "Дитячі суміші", 3, "Дитячі суміші", 126 },
                    { 783, "Стільчики для годування", 3, "Стільчики для годування", 126 },
                    { 784, "Пляшечки для годування та аксесуари", 3, "Пляшечки для годування та аксесуари", 126 },
                    { 785, "Дитячі кухонні комбайни", 3, "Дитячі кухонні комбайни", 126 },
                    { 786, "Дитячі каші", 3, "Дитячі каші", 126 },
                    { 787, "Дитяче пюре", 3, "Дитяче пюре", 126 },
                    { 788, "Дитячий посуд", 3, "Дитячий посуд", 126 },
                    { 789, "Пустушки", 3, "Пустушки", 126 },
                    { 790, "Електротранспорт", 3, "Електротранспорт", 128 },
                    { 791, "Дитячі коляски", 3, "Дитячі коляски", 128 },
                    { 792, "Дитячі автокрісла", 3, "Дитячі автокрісла", 128 },
                    { 793, "Дитячі велосипеди", 3, "Дитячі велосипеди", 128 },
                    { 794, "Дитячі самокати", 3, "Дитячі самокати", 128 },
                    { 795, "Дивомобілі, ходунки, гойдалки", 3, "Дивомобілі, ходунки, гойдалки", 128 },
                    { 796, "Роликові ковзани", 3, "Роликові ковзани", 128 },
                    { 797, "Підгузки", 3, "Підгузки", 129 },
                    { 798, "Дитячі серветки, хусточки та рушники", 3, "Дитячі серветки, хусточки та рушники", 129 },
                    { 799, "Пелюшки", 3, "Пелюшки", 129 },
                    { 800, "Косметика для догляду для дітей", 3, "Косметика для догляду для дітей", 129 },
                    { 801, "Дитячі ванночки та аксесуари", 3, "Дитячі ванночки та аксесуари", 129 },
                    { 802, "Одяг для хлопчиків", 3, "Одяг для хлопчиків", 130 },
                    { 803, "Одяг для дівчаток", 3, "Одяг для дівчаток", 130 },
                    { 804, "Одяг для малюків", 3, "Одяг для малюків", 130 },
                    { 805, "Дитяче взуття", 3, "Дитяче взуття", 130 },
                    { 806, "Шкільні набори та ранці", 3, "Шкільні набори та ранці", 131 },
                    { 807, "Шкільні пенали", 3, "Шкільні пенали", 131 },
                    { 808, "Сумки для взуття", 3, "Сумки для взуття", 131 },
                    { 809, "Радіоняньки", 3, "Радіоняньки", 133 },
                    { 810, "Парти", 3, "Парти", 133 },
                    { 811, "Манежі", 3, "Манежі", 133 },
                    { 812, "Мобілі", 3, "Мобілі", 133 },
                    { 813, "Дитячі ліжечка", 3, "Дитячі ліжечка", 133 },
                    { 814, "Творчість", 3, "Творчість", 134 },
                    { 815, "Розвивальні іграшки", 3, "Розвивальні іграшки", 134 },
                    { 816, "Дитячі книги", 3, "Дитячі книги", 134 },
                    { 817, "Корми для кішок", 3, "Корми для кішок", 138 },
                    { 818, "Вологий корм для кішок", 3, "Вологий корм для кішок", 138 },
                    { 819, "Сухий корм для кішок", 3, "Сухий корм для кішок", 138 },
                    { 820, "Корма для кошенят", 3, "Корма для кошенят", 138 },
                    { 821, "Засоби для догляду та гігієни для кішок", 3, "Засоби для догляду та гігієни для кішок", 138 },
                    { 822, "Вітаміни та ласощі для кішок", 3, "Вітаміни та ласощі для кішок", 138 },
                    { 823, "Спальні місця та перенесення для кішок", 3, "Спальні місця та перенесення для кішок", 138 },
                    { 824, "Іграшки для котів", 3, "Іграшки для котів", 138 },
                    { 825, "Туалети для кішок", 3, "Туалети для кішок", 138 },
                    { 826, "Посуд для котів", 3, "Посуд для котів", 138 },
                    { 827, "Грумінг кішкам", 3, "Грумінг кішкам", 138 },
                    { 828, "Деревні", 3, "Деревні", 139 },
                    { 829, "Бентонітові", 3, "Бентонітові", 139 },
                    { 830, "Силікагелеві", 3, "Силікагелеві", 139 },
                    { 831, "Корм для птахів", 3, "Корм для птахів", 140 },
                    { 832, "Клітки для птахів", 3, "Клітки для птахів", 140 },
                    { 833, "Корм для гризунів", 3, "Корм для гризунів", 141 },
                    { 834, "Наповнювачі туалетів для гризунів", 3, "Наповнювачі туалетів для гризунів", 141 },
                    { 835, "Клітки для гризунів", 3, "Клітки для гризунів", 141 },
                    { 836, "Корми для собак", 3, "Корми для собак", 142 },
                    { 837, "Сухий корм для собак", 3, "Сухий корм для собак", 142 },
                    { 838, "Вологий корм для собак", 3, "Вологий корм для собак", 142 },
                    { 839, "Корма для цуценят", 3, "Корма для цуценят", 142 },
                    { 840, "Вітаміни та ласощі для собак", 3, "Вітаміни та ласощі для собак", 142 },
                    { 841, "Засоби для догляду та гігієни для собак", 3, "Засоби для догляду та гігієни для собак", 142 },
                    { 842, "Посуд для тварин", 3, "Посуд для тварин", 142 },
                    { 843, "Одяг для собак", 3, "Одяг для собак", 142 },
                    { 844, "Нашийники для собак", 3, "Нашийники для собак", 142 },
                    { 845, "Повідці для собак", 3, "Повідці для собак", 142 },
                    { 846, "Спальні місця та переноски", 3, "Спальні місця та переноски", 142 },
                    { 847, "Іграшки для собак", 3, "Іграшки для собак", 142 },
                    { 848, "Засоби від бліх та кліщів", 3, "Засоби від бліх та кліщів", 143 },
                    { 849, "Засоби проти глистів", 3, "Засоби проти глистів", 143 },
                    { 850, "Протигрибкові засоби", 3, "Протигрибкові засоби", 143 },
                    { 851, "Нашийники від бліх", 3, "Нашийники від бліх", 143 },
                    { 852, "Краплі та таблетки від паразитів", 3, "Краплі та таблетки від паразитів", 143 },
                    { 853, "Засоби для обробки приміщень", 3, "Засоби для обробки приміщень", 143 },
                    { 854, "Засоби від неприємного запаху", 3, "Засоби від неприємного запаху", 143 },
                    { 855, "Для привчання до туалету", 3, "Для привчання до туалету", 143 },
                    { 856, "Корми для риб", 3, "Корми для риб", 144 },
                    { 857, "Фільтри", 3, "Фільтри", 144 },
                    { 858, "Компресори та помпи", 3, "Компресори та помпи", 144 },
                    { 859, "Освітлення", 3, "Освітлення", 144 },
                    { 860, "Декорації", 3, "Декорації", 144 },
                    { 861, "Корм для рептилій", 3, "Корм для рептилій", 145 },
                    { 862, "Освітлення", 3, "Освітлення", 145 },
                    { 863, "Фаунаріуми", 3, "Фаунаріуми", 145 },
                    { 864, "Папір офісний", 3, "Папір офісний", 148 },
                    { 865, "Ручки", 3, "Ручки", 148 },
                    { 866, "Щоденники, планінги, алфавітні книги", 3, "Щоденники, планінги, алфавітні книги", 148 },
                    { 867, "Папки-реєстратори", 3, "Папки-реєстратори", 148 },
                    { 868, "Циркулі та готувальнички", 3, "Циркулі та готувальнички", 148 },
                    { 869, "Блокноти, зошити офісні", 3, "Блокноти, зошити офісні", 148 },
                    { 870, "Олівці", 3, "Олівці", 148 },
                    { 871, "Файли", 3, "Файли", 148 },
                    { 872, "Клей", 3, "Клей", 148 },
                    { 873, "Коректори", 3, "Коректори", 148 },
                    { 874, "Лотки для паперів", 3, "Лотки для паперів", 148 },
                    { 875, "Маркери", 3, "Маркери", 148 },
                    { 876, "Папір для нотаток, стикери", 3, "Папір для нотаток, стикери", 148 },
                    { 877, "Гумки", 3, "Гумки", 148 },
                    { 878, "Степлери, скоби, антистеплери", 3, "Степлери, скоби, антистеплери", 148 },
                    { 879, "Клейкі стрічки та скотчі", 3, "Клейкі стрічки та скотчі", 148 },
                    { 880, "Конверти", 3, "Конверти", 148 },
                    { 881, "Папки з файлами", 3, "Папки з файлами", 148 },
                    { 882, "Папір для фліпчартів", 3, "Папір для фліпчартів", 148 },
                    { 883, "Стрижні, грифелі, чорнило", 3, "Стрижні, грифелі, чорнило", 148 },
                    { 884, "Лупи", 3, "Лупи", 148 },
                    { 885, "Шкільні набори та ранці", 3, "Шкільні набори та ранці", 149 },
                    { 886, "Зошити учнівські", 3, "Зошити учнівські", 149 },
                    { 887, "Пенали шкільні", 3, "Пенали шкільні", 149 },
                    { 888, "Обкладинки для зошитів і підручників", 3, "Обкладинки для зошитів і підручників", 149 },
                    { 889, "Сумки шкільні", 3, "Сумки шкільні", 149 },
                    { 890, "Бутербродниці (ланч-бокси)", 3, "Бутербродниці (ланч-бокси)", 149 },
                    { 891, "Контурні мапи та атласи", 3, "Контурні мапи та атласи", 149 },
                    { 892, "Лінійки, транспортири, косинці", 3, "Лінійки, транспортири, косинці", 149 },
                    { 893, "Ножиці шкільні", 3, "Ножиці шкільні", 149 },
                    { 894, "Калькулятори", 3, "Калькулятори", 150 },
                    { 895, "Папки пластикові", 3, "Папки пластикові", 150 },
                    { 896, "Самонабірні штампи", 3, "Самонабірні штампи", 150 },
                    { 897, "Настільні набори", 3, "Настільні набори", 150 },
                    { 898, "Діркопробивачі", 3, "Діркопробивачі", 150 },
                    { 899, "Бейджі, брелоки-ідентифікатори, настільні таблички", 3, "Бейджі, брелоки-ідентифікатори, настільні таблички", 150 },
                    { 900, "Папки-портфелі, папки-бокси", 3, "Папки-портфелі, папки-бокси", 150 },
                    { 901, "Друк візиток", 3, "Друк візиток", 150 },
                    { 902, "Художня література", 3, "Художня література", 152 },
                    { 903, "Дитячі книги", 3, "Дитячі книги", 152 },
                    { 904, "Книги для бізнесу", 3, "Книги для бізнесу", 152 },
                    { 905, "Підручники. Науково-методична література", 3, "Підручники. Науково-методична література", 152 },
                    { 906, "Релігія. Езотерика", 3, "Релігія. Езотерика", 152 },
                    { 907, "Словники. Довідники. Енциклопедії", 3, "Словники. Довідники. Енциклопедії", 152 },
                    { 908, "Книги для батьків", 3, "Книги для батьків", 152 },
                    { 909, "Кольорові олівці", 3, "Кольорові олівці", 152 },
                    { 910, "Фарби", 3, "Фарби", 152 },
                    { 911, "Кольоровий папір і картон", 3, "Кольоровий папір і картон", 152 },
                    { 912, "Альбоми для малювання", 3, "Альбоми для малювання", 152 },
                    { 913, "Пластилін", 3, "Пластилін", 152 },
                    { 914, "Фломастери", 3, "Фломастери", 152 },
                    { 915, "Пензлі", 3, "Пензлі", 152 },
                    { 916, "Мольберти, етюдники, палітри", 3, "Мольберти, етюдники, палітри", 152 },
                    { 917, "Головоломки, антистреси", 3, "Головоломки, антистреси", 154 },
                    { 918, "Вино - Червоне", 3, "Червоне", 155 },
                    { 919, "Вино - Біле", 3, "Біле", 155 },
                    { 920, "Вино - Рожеве", 3, "Рожеве", 155 },
                    { 921, "Вино - Сухе вино", 3, "Сухе вино", 155 },
                    { 922, "Вино - Напівсолодке вино", 3, "Напівсолодке вино", 155 },
                    { 923, "Вино - Напівсухе вино", 3, "Напівсухе вино", 155 },
                    { 924, "Вино - Десертне", 3, "Десертне", 155 },
                    { 925, "Вино - Ігристе шампанське", 3, "Ігристе шампанське", 155 },
                    { 926, "Лікери, вермути, сиропи - Лікери", 3, "Лікери", 156 },
                    { 927, "Лікери, вермути, сиропи - Вермути", 3, "Вермути", 156 },
                    { 928, "Лікери, вермути, сиропи - Сиропи", 3, "Сиропи", 156 },
                    { 929, "Лікери, вермути, сиропи - Набори", 3, "Набори", 156 },
                    { 930, "Посуд - Келихи та фужери", 3, "Келихи та фужери", 159 },
                    { 931, "Посуд - Стопки та чарки", 3, "Стопки та чарки", 159 },
                    { 932, "Міцні напої - Віскі бленд", 3, "Віскі бленд", 160 },
                    { 933, "Міцні напої - Віскі бурбон", 3, "Віскі бурбон", 160 },
                    { 934, "Міцні напої - Коньяк", 3, "Коньяк", 160 },
                    { 935, "Міцні напої - Віскі односолодовий", 3, "Віскі односолодовий", 160 },
                    { 936, "Міцні напої - Горілка", 3, "Горілка", 160 },
                    { 937, "Міцні напої - Ром", 3, "Ром", 160 },
                    { 938, "Міцні напої - Абсент", 3, "Абсент", 160 },
                    { 939, "Міцні напої - Текіла", 3, "Текіла", 160 },
                    { 940, "Міцні напої - Арманьяк", 3, "Арманьяк", 160 },
                    { 941, "Міцні напої - Бренді", 3, "Бренді", 160 },
                    { 942, "Міцні напої - Чача", 3, "Чача", 160 },
                    { 943, "Міцні напої - Джин", 3, "Джин", 160 },
                    { 944, "Міцні напої - Кальвадос", 3, "Кальвадос", 160 },
                    { 945, "Міцні напої - Бітер", 3, "Бітер", 160 },
                    { 946, "Міцні напої - Грапа", 3, "Грапа", 160 },
                    { 947, "Міцні напої - Саке", 3, "Саке", 160 },
                    { 948, "Електронні сигарети та аксесуари - Електронні сигарети, батарейні моди, атомайзери", 3, "Електронні сигарети, батарейні моди, атомайзери", 161 },
                    { 949, "Електронні сигарети та аксесуари - Комплектовання та аксесуари для електронних сигарет", 3, "Комплектовання та аксесуари для електронних сигарет", 161 },
                    { 950, "Електронні сигарети та аксесуари - Рідини для електронних сигарет", 3, "Рідини для електронних сигарет", 161 },
                    { 951, "Електронні сигарети та аксесуари - Компоненти для рідин", 3, "Компоненти для рідин", 161 },
                    { 952, "Продукти - Шоколад та цукерки", 3, "Шоколад та цукерки", 162 },
                    { 953, "Продукти - Кава", 3, "Кава", 162 },
                    { 954, "Продукти - Чай", 3, "Чай", 162 },
                    { 955, "Продукти - Рибні консерви", 3, "Рибні консерви", 162 },
                    { 956, "Продукти - Вода, соки, напої", 3, "Вода, соки, напої", 162 },
                    { 957, "Продукти - Олія", 3, "Олія", 162 },
                    { 958, "Продукти - Соуси", 3, "Соуси", 162 },
                    { 959, "Продукти - Макаронні вироби", 3, "Макаронні вироби", 162 },
                    { 960, "Продукти - Драже, льодяники, пастилки", 3, "Драже, льодяники, пастилки", 162 },
                    { 961, "Продукти - Батончики", 3, "Батончики", 162 },
                    { 962, "Продукти - Оливки", 3, "Оливки", 162 },
                    { 963, "Продукти - Снеки", 3, "Снеки", 162 },
                    { 964, "Продукти - Жувальна гумка", 3, "Жувальна гумка", 162 },
                    { 965, "Продукти - Джем і варення", 3, "Джем і варення", 162 },
                    { 966, "Продукти - Оцет", 3, "Оцет", 162 },
                    { 967, "Продукти - Приправи та спеції", 3, "Приправи та спеції", 162 },
                    { 968, "Продукти - Продукти для суші", 3, "Продукти для суші", 162 },
                    { 969, "Продукти - Сухі сніданки", 3, "Сухі сніданки", 162 },
                    { 970, "Продукти - Дитяче харчування", 3, "Дитяче харчування", 162 },
                    { 971, "Продукти - Крупи", 3, "Крупи", 162 },
                    { 972, "Продукти - Овочева консервація", 3, "Овочева консервація", 162 },
                    { 973, "Продукти - Сиропи та топінги", 3, "Сиропи та топінги", 162 },
                    { 974, "Продукти - Фруктова консервація", 3, "Фруктова консервація", 162 },
                    { 975, "Продукти - Слабоалкогольні напої", 3, "Слабоалкогольні напої", 162 },
                    { 976, "Продукти - Хлібці та галети", 3, "Хлібці та галети", 162 },
                    { 977, "Засоби для прання - Пральні засоби", 3, "Пральні засоби", 163 },
                    { 978, "Засоби для прання - Кондиціонери для білизни", 3, "Кондиціонери для білизни", 163 },
                    { 979, "Засоби для прання - Плямовивідники і відбілювачі", 3, "Плямовивідники і відбілювачі", 163 },
                    { 980, "Засоби для догляду за будинком - Засоби для кухні", 3, "Засоби для кухні", 164 },
                    { 981, "Засоби для догляду за будинком - Догляд за побутовою технікою", 3, "Догляд за побутовою технікою", 164 },
                    { 982, "Засоби для догляду за будинком - Засоби для миття підлог", 3, "Засоби для миття підлог", 164 },
                    { 983, "Засоби для догляду за будинком - Засоби для миття вікон", 3, "Засоби для миття вікон", 164 },
                    { 984, "Засоби для догляду за будинком - Прибирання після ремонту", 3, "Прибирання після ремонту", 164 },
                    { 985, "Засоби для догляду за ванною та туалетом - Для ванної", 3, "Для ванної", 165 },
                    { 986, "Засоби для догляду за ванною та туалетом - Для туалету", 3, "Для туалету", 165 },
                    { 987, "Засоби для догляду за ванною та туалетом - Туалетні блоки", 3, "Туалетні блоки", 165 },
                    { 988, "Засоби для догляду за ванною та туалетом - Освіжувачі повітря", 3, "Освіжувачі повітря", 165 },
                    { 989, "Засоби для миття посуду - Засоби для посудомийних машин", 3, "Засоби для посудомийних машин", 166 },
                    { 990, "Засоби для миття посуду - Мийні засоби", 3, "Мийні засоби", 166 },
                    { 991, "Засоби для миття посуду - Догляд за посудомийними машинами", 3, "Догляд за посудомийними машинами", 166 },
                    { 992, "Господарські товари - Туалетний папір", 3, "Туалетний папір", 167 },
                    { 993, "Господарські товари - Паперові рушники", 3, "Паперові рушники", 167 },
                    { 994, "Господарські товари - Серветки", 3, "Серветки", 167 },
                    { 995, "Господарські товари - Харчова упаковка", 3, "Харчова упаковка", 167 },
                    { 996, "Господарські товари - Пакети для сміття", 3, "Пакети для сміття", 167 },
                    { 997, "Вулична зона - Засоби від комах", 3, "Засоби від комах", 168 },
                    { 998, "Вулична зона - Отрута для гризунів", 3, "Отрута для гризунів", 168 },
                    { 999, "Вулична зона - Засоби для вигрібних ям та септиків", 3, "Засоби для вигрібних ям та септиків", 168 },
                    { 1000, "Вулична зона - Хімія для басейнів і систем опалення", 3, "Хімія для басейнів і систем опалення", 168 },
                    { 1001, "Екологічні та органічні засоби - Засоби для прання", 3, "Засоби для прання", 169 },
                    { 1002, "Екологічні та органічні засоби - Засоби для миття посуду", 3, "Засоби для миття посуду", 169 },
                    { 1003, "Екологічні та органічні засоби - Засоби для прибирання", 3, "Засоби для прибирання", 169 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 720);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 723);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 726);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 727);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 728);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 729);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 730);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 733);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 734);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 735);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 737);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 738);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 739);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 742);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 743);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 835);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 836);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 837);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 838);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 839);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 841);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 842);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 843);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 844);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 845);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 846);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 847);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 848);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 849);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 851);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 852);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 853);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 855);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 856);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 857);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 858);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 859);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 860);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 861);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 862);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 863);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 864);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 865);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 866);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 867);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 868);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 869);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 870);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 871);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 872);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 873);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 874);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 875);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 877);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 879);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 880);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 881);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 882);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 883);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 884);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 885);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 886);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 887);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 888);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 889);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 890);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 891);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 892);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 893);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 894);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 895);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 896);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 897);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 898);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 899);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 904);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 905);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 906);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 907);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 908);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 909);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 910);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 911);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 912);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 913);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 914);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 915);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 916);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 917);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 918);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 919);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 920);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 921);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 922);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 923);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 924);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 925);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 926);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 927);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 928);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 929);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 930);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 931);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 932);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 933);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 934);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 935);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 936);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 937);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 938);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 939);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 940);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 941);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 942);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 943);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 944);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 945);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 946);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 947);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 948);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 949);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 950);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 951);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 952);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 953);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 954);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 955);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 956);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 957);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 958);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 959);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 960);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 961);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 962);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 963);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 964);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 965);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 966);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 967);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 968);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 969);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 970);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 971);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 972);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 973);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 974);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 975);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 976);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 977);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 978);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 979);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 980);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 981);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 982);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 983);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 984);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 985);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 986);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 987);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 988);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 989);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 990);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 991);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 992);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 993);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 994);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 995);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 996);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 997);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 998);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ноутбуки", 2, "Ноутбуки", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Планшети", 2, "Планшети", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комп'ютери", 2, "Комп'ютери", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комплектуючi", 2, "Комплектуючi", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Аксесуари для ноутбуків і ПК", 2, "Аксесуари для ноутбуків і ПК", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Серверне обладнання", 2, "Серверне обладнання", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Товари з уцінкою", 2, "Товари з уцінкою", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Офісна техніка", 2, "Офісна техніка", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Інтерактивне обладнання", 2, "Інтерактивне обладнання", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мережеве обладнання", 2, "Мережеве обладнання", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Товари для геймерів", 2, "Товари для геймерів", 1 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Asus", 3, "Asus", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Lenovo", 3, "Lenovo", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Acer", 3, "Acer", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "HP (Hewlett Packard)", 3, "HP (Hewlett Packard)", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Dell", 3, "Dell", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Apple Macbook", 3, "Apple Macbook", 2 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Apple iPad", 3, "Apple iPad", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Samsung", 3, "Samsung", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Lenovo", 3, "Lenovo", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Xiaomi", 3, "Xiaomi", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Чохли для планшетів", 3, "Чохли для планшетів", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Захисні плівки та скло", 3, "Захисні плівки та скло", 3 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Монітори", 3, "Монітори", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Клавіатури та миші", 3, "Клавіатури та миші", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комп'ютерні колонки", 3, "Комп'ютерні колонки", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Програмне забезпечення", 3, "Програмне забезпечення", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Джерела безперебійного живлення", 3, "Джерела безперебійного живлення", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Акумулятори для ДБЖ", 3, "Акумулятори для ДБЖ", 4 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Відеокарти", 3, "Відеокарти", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "SSD", 3, "SSD", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Процесори", 3, "Процесори", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Жорсткі диски та дискові масиви", 3, "Жорсткі диски та дискові масиви", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Оперативна пам'ять", 3, "Оперативна пам'ять", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Материнські плати", 3, "Материнські плати", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Блоки живлення", 3, "Блоки живлення", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Корпуси", 3, "Корпуси", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Системи охолодження", 3, "Системи охолодження", 5 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Флеш пам'ять USB", 3, "Флеш пам'ять USB", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мережеві фільтри, адаптери та подовжувачі", 3, "Мережеві фільтри, адаптери та подовжувачі", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Сумки, рюкзаки та чохли для ноутбуків", 3, "Сумки, рюкзаки та чохли для ноутбуків", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Підставки та столики для ноутбуків", 3, "Підставки та столики для ноутбуків", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Веб-камери", 3, "Веб-камери", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Навушники", 3, "Навушники", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мікрофони", 3, "Мікрофони", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Універсальні мобільні батареї для ноутбуків", 3, "Універсальні мобільні батареї для ноутбуків", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Кабелі та перехідники", 3, "Кабелі та перехідники", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Графічні планшети", 3, "Графічні планшети", 6 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "БФП/Принтери", 3, "БФП/Принтери", 9 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Витратні матеріали", 3, "Витратні матеріали", 9 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Шредери", 3, "Шредери", 9 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Телефони", 3, "Телефони", 9 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Маршрутизатори", 3, "Маршрутизатори", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Комутатори", 3, "Комутатори", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мережеві адаптери", 3, "Мережеві адаптери", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ретранслятори Wi-Fi", 3, "Ретранслятори Wi-Fi", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Бездротові точки доступу", 3, "Бездротові точки доступу", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Мережеві сховища (NAS)", 3, "Мережеві сховища (NAS)", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Патч-корди", 3, "Патч-корди", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "IP-телефонія", 3, "IP-телефонія", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Підсилювачі зв'язку", 3, "Підсилювачі зв'язку", 11 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "PlayStation", 3, "PlayStation", 12 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Sony PlayStation 5", 3, "Sony PlayStation 5", 12 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові консолі та дитячі приставки", 3, "Ігрові консолі та дитячі приставки", 12 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові маніпулятори та аксесуари для консолей", 3, "Ігрові маніпулятори та аксесуари для консолей", 12 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігри", 3, "Ігри", 12 });

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "Description", "Level", "Name", "TopId" },
                values: new object[] { "Ігрові поверхні", 3, "Ігрові поверхні", 12 });

      
        }
    }
}
