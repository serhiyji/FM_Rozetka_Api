using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FM_Rozetka_Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryProductSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Ноутбуки та комп'ютери", "Ноутбуки та комп'ютери" });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "Id", "Description", "Level", "Name", "TopId" },
                values: new object[,]
                {
                    { 2, "Ноутбуки", 2, "Ноутбуки", 1 },
                    { 3, "Планшети", 2, "Планшети", 1 },
                    { 4, "Комп'ютери", 2, "Комп'ютери", 1 },
                    { 5, "Комплектуючi", 2, "Комплектуючi", 1 },
                    { 6, "Аксесуари для ноутбуків і ПК", 2, "Аксесуари для ноутбуків і ПК", 1 },
                    { 7, "Серверне обладнання", 2, "Серверне обладнання", 1 },
                    { 8, "Товари з уцінкою", 2, "Товари з уцінкою", 1 },
                    { 9, "Офісна техніка", 2, "Офісна техніка", 1 },
                    { 10, "Інтерактивне обладнання", 2, "Інтерактивне обладнання", 1 },
                    { 11, "Мережеве обладнання", 2, "Мережеве обладнання", 1 },
                    { 12, "Товари для геймерів", 2, "Товари для геймерів", 1 },
                    { 13, "Asus", 3, "Asus", 2 },
                    { 14, "Lenovo", 3, "Lenovo", 2 },
                    { 15, "Acer", 3, "Acer", 2 },
                    { 16, "HP (Hewlett Packard)", 3, "HP (Hewlett Packard)", 2 },
                    { 17, "Dell", 3, "Dell", 2 },
                    { 18, "Apple Macbook", 3, "Apple Macbook", 2 },
                    { 19, "Apple iPad", 3, "Apple iPad", 3 },
                    { 20, "Samsung", 3, "Samsung", 3 },
                    { 21, "Lenovo", 3, "Lenovo", 3 },
                    { 22, "Xiaomi", 3, "Xiaomi", 3 },
                    { 23, "Чохли для планшетів", 3, "Чохли для планшетів", 3 },
                    { 24, "Захисні плівки та скло", 3, "Захисні плівки та скло", 3 },
                    { 25, "Монітори", 3, "Монітори", 4 },
                    { 26, "Клавіатури та миші", 3, "Клавіатури та миші", 4 },
                    { 27, "Комп'ютерні колонки", 3, "Комп'ютерні колонки", 4 },
                    { 28, "Програмне забезпечення", 3, "Програмне забезпечення", 4 },
                    { 29, "Джерела безперебійного живлення", 3, "Джерела безперебійного живлення", 4 },
                    { 30, "Акумулятори для ДБЖ", 3, "Акумулятори для ДБЖ", 4 },
                    { 31, "Відеокарти", 3, "Відеокарти", 5 },
                    { 32, "SSD", 3, "SSD", 5 },
                    { 33, "Процесори", 3, "Процесори", 5 },
                    { 34, "Жорсткі диски та дискові масиви", 3, "Жорсткі диски та дискові масиви", 5 },
                    { 35, "Оперативна пам'ять", 3, "Оперативна пам'ять", 5 },
                    { 36, "Материнські плати", 3, "Материнські плати", 5 },
                    { 37, "Блоки живлення", 3, "Блоки живлення", 5 },
                    { 38, "Корпуси", 3, "Корпуси", 5 },
                    { 39, "Системи охолодження", 3, "Системи охолодження", 5 },
                    { 40, "Флеш пам'ять USB", 3, "Флеш пам'ять USB", 6 },
                    { 41, "Мережеві фільтри, адаптери та подовжувачі", 3, "Мережеві фільтри, адаптери та подовжувачі", 6 },
                    { 42, "Сумки, рюкзаки та чохли для ноутбуків", 3, "Сумки, рюкзаки та чохли для ноутбуків", 6 },
                    { 43, "Підставки та столики для ноутбуків", 3, "Підставки та столики для ноутбуків", 6 },
                    { 44, "Веб-камери", 3, "Веб-камери", 6 },
                    { 45, "Навушники", 3, "Навушники", 6 },
                    { 46, "Мікрофони", 3, "Мікрофони", 6 },
                    { 47, "Універсальні мобільні батареї для ноутбуків", 3, "Універсальні мобільні батареї для ноутбуків", 6 },
                    { 48, "Кабелі та перехідники", 3, "Кабелі та перехідники", 6 },
                    { 49, "Графічні планшети", 3, "Графічні планшети", 6 },
                    { 50, "БФП/Принтери", 3, "БФП/Принтери", 9 },
                    { 51, "Витратні матеріали", 3, "Витратні матеріали", 9 },
                    { 52, "Шредери", 3, "Шредери", 9 },
                    { 53, "Телефони", 3, "Телефони", 9 },
                    { 54, "Маршрутизатори", 3, "Маршрутизатори", 11 },
                    { 55, "Комутатори", 3, "Комутатори", 11 },
                    { 56, "Мережеві адаптери", 3, "Мережеві адаптери", 11 },
                    { 57, "Ретранслятори Wi-Fi", 3, "Ретранслятори Wi-Fi", 11 },
                    { 58, "Бездротові точки доступу", 3, "Бездротові точки доступу", 11 },
                    { 59, "Мережеві сховища (NAS)", 3, "Мережеві сховища (NAS)", 11 },
                    { 60, "Патч-корди", 3, "Патч-корди", 11 },
                    { 61, "IP-телефонія", 3, "IP-телефонія", 11 },
                    { 62, "Підсилювачі зв'язку", 3, "Підсилювачі зв'язку", 11 },
                    { 63, "PlayStation", 3, "PlayStation", 12 },
                    { 64, "Sony PlayStation 5", 3, "Sony PlayStation 5", 12 },
                    { 65, "Ігрові консолі та дитячі приставки", 3, "Ігрові консолі та дитячі приставки", 12 },
                    { 66, "Ігрові маніпулятори та аксесуари для консолей", 3, "Ігрові маніпулятори та аксесуари для консолей", 12 },
                    { 67, "Ігри", 3, "Ігри", 12 },
                    { 68, "Ігрові поверхні", 3, "Ігрові поверхні", 12 }
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.UpdateData(
                table: "CategoryProducts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Test", "Test" });

        }
    }
}
