nopCommerce FULL STACK ASP.NET DEVELOPER (REMOTE)
===========
Ahoj there!

This repository was created for the best possible dream job interview purposes: nopCommerce dev. Two tasks were specified within the interview process. You can read more on [official interview form](https://www.nopcommerce.com/vacancy-developer-remote.aspx).

I am working as a developer since 2009 (the Middle Ages with turned off JavaScript and IE6 everywhere omg). 
My first programming language, as for many others, was PHP. I was working on bazillion ecommerce projects based on many technologies:
* Magento
* Typo3
* WooCommerce
* CakePHP, custom frameworks, etc.

Later on I've become a **.NET developer**. YEAH! C# is the best language in the world! Ask Steve!
![.NET .NET .NET](http://nopcommerce.abtec.cz/steve.gif)
I was working on many cool projects within my career. 
Hey did you see some [2018 World Cup](https://en.wikipedia.org/wiki/2018_FIFA_World_Cup) football match in Russia? Our cool .NET hardcore system was running during the each match. You can read more about my on my [linkedin profile](https://www.linkedin.com/in/andrejbeles/)

But in last few years I have totally fall in love with nopCommerce. I was playing with it since version 2.x.
The last projects that I can mentioned are:

[Belle Parfumerie](https://www.belleparfumerie.cz/cs/) - Online perfumery with custom plugins, for example import plugin which is each hour parsing xml feed with more than 40k products.

[SoundRoseStudio](https://www.soundrosestudio.com/) - Online Royalty Free Music Store

Both are running under 3.90 version. Migration to 4.00 is planned within a few weeks.

But nowadays I have only one target. To become a core nopCommerce developer. Can you imagine that? Absolutely mind-blowing

![BOOOM](http://nopcommerce.abtec.cz/mind.gif)

Now let's talk about our tasks in detail:
=============
**Task #1**
You have an online store that sells books. Add a new “Author” property to “Product” entity. A store owner should be able to edit it in admin area. And it should be displayed to customers in public store. 
---
This task is very disputable in my eyes. I believe that the right solution depends on the point of view:
 * If I am a developer implementing a bookstore for my customer I would recommend him/her to use [Specification attributes](http://docs.nopcommerce.com/display/en/Specification+attributes). It's the easiest and the cheapest way how to add/edit Author attribute.
 
    | Pros           | Cons           |
    | ------------- |----------------|
    | This is for what nopCommerce has been created       | There is nothing I can commit lol |
    
 * If I am a core nop developer the greatest possible way is to extend core Product entity. You can see how to do it in my
  [abeles/task1](https://github.com/abTec/nopCommerce/tree/abeles/task1) branch.
  
    | Pros           | Cons           |
    | ------------- |----------------|
    | Easy to implement     | Touching the core. You can have some conflicts in the code in the future, but we are GIT gurus, right? So, no fear |
* If I want to show you how cool I can code or just don't want to touch the core files I can implement custom plugin. This solution is the most sophisticated and can be tricky but maybe also the most "data pattern clear". How to do it?
    * I need to create a new custom plugin with Data Access Layer
    * Create a domain object with Author property and ProductId property to create a relation bewtween Product and my table.
    * Override product view to call my service and display author field from database.
    * Override admin product edit/add view and also controller (or service) to handle saving author
    
    | Pros           | Cons           |
    | ------------- |----------------|
    | Can be fun during implementation     | Very large bag of changes need to be done. So there is a space for possible bugs. |
    |My Pull Request would be glorious :)|Time consuming == expensive

**Task #2**
Implement a new widget plugin (IWidgetPlugin). This plugin should display a message on the product details page in public store (e.g. “50% discount in December”). And this message should be editable in admin area on the widget configuration page.
---
This task was really straightforward. There was nothing to speculate about. I've just created a new plugin called **Product Detail Message Widget**. 
![Plugin Page](http://nopcommerce.abtec.cz/plugin.png)

I've added the multistore and also multilingual support. The plugin also has IsEnabled setting to allow disable/enable it on product details page.
![Configuration Page](http://nopcommerce.abtec.cz/widget.png)
You can see my progress in branch [abeles/task2](https://github.com/abTec/nopCommerce/tree/abeles/task2). 
And here is the final [Pull Request](https://github.com/abTec/nopCommerce/pull/1) into to the develop branch. Woohoo! So fun!
Both tasks are merged and deployed **[here](http://194.182.82.20)**

If you have any question do not hesitate to contact me at:
nopcommerce@abtec.cz
or via [LinkedIn](https://www.linkedin.com/in/andrejbeles/).
## Resources: ##
You can see my running solution here: [~~NopCommerce~~](http://194.182.82.20)
:warning: SITE IS DOWN IF YOU WANNA SEE IT WRITE ME A MESSAGE
admin: nopcommerce@abtec.cz
p: parol2018

CV in pdf: [http://nopcommerce.abtec.cz/cv_beles_eng.pdf](http://nopcommerce.abtec.cz/cv_beles_eng.pdf)

nopCommerce official site: [https://www.nopcommerce.com](https://www.nopcommerce.com)

My LinkedIn profile: https://www.linkedin.com/in/andrejbeles/

Thanks!
