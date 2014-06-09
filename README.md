Social Meta Tags - Orchard CMS Module
=========

Content part for Social Meta Tags (Open Graph Tags for Facebook/Google/Pinterest/Linkedin and Twitter Card Tags)

**Social Meta Tags Orchard Module** allows content author to enter various Social Meta Tags inputs and then module renders meta tag output on the page. 

It has 3 attachable content part which can be attached to Page or Blog or BlogPost.

**1) Authorship Meta Tags Part **

This Content part renders author=rel and author=pulisher tag which is useful in Google Search Results Page. Using these tags do require one time verification by Google.

**2) Open Graph Meta Tags Part **

Attaching this content part allows for basic Open Graph Meta Tags for Social Sharing on Facebook, Google+, Twitter, Linkedin, Pinterest. It has support for og:type, og:title, og:image, og:url, og:description, og:locale, og:site_name and fb:admins.

**3) Twitter Summary Card Meta Tags Part**

Attaching this content part allows for meta tags for sharing on Twitter. This has support for twitter:card, twitter:title, twitter:description, twitter:image, twitter:creator, twitter:site. Using these tags require one time verification by Twitter.

Version
----

1.0


Installation
--------------

```sh
Orchard Version Requirement: 1.8

Use Orchard Gallery to install the module. 

https://gallery.orchardproject.net/List/Modules/Orchard.Module.Om.Orchard.SocialMetaTags

```

Configuration
--------------
```sh

Once module is successfully installed, under Settings -> Social Meta Tags to configure it.

Each tag can be enabled or required. Further few tags can be preset for all the content.

```

Showing below Open Graph Configuration:

![alt tag](http://www.bhavindoshi.com/socialtags/og-1.JPG)

Attaching Parts to Page Module:

![alt tag](http://www.bhavindoshi.com/socialtags/three-part-selections.png)


Usage
-------------
**Tags Input Screen for each content part**

**Google Authorship**
![alt tag](http://www.bhavindoshi.com/socialtags/screen2.jpg)

**Open Graph Tags**
![alt tag](http://www.bhavindoshi.com/socialtags/screen1.jpg)

**Twitter Summary cards Tags**
![alt tag](http://www.bhavindoshi.com/socialtags/screen3.jpg)

**Output Tags Renderd**
![alt tag](http://www.bhavindoshi.com/socialtags/screen4.jpg)



Tags Documenation & Verification Links
--------------

 - Open Graph - Facebook Debugger
  - Open Graph Tags: http://ogp.me/ 
  - Testing Tool https://developers.facebook.com/tools/debug/


- Google+ Authorship 

 - Google+ Snippet https://developers.google.com/+/web/snippet/
 + Structured Data Testing Tool: http://www.google.com/webmasters/tools/richsnippets 
 + Authorship Verification https://support.google.com/webmasters/answer/2539557?hl=en


- Twiiter Summary Cards
 - Card Tags https://dev.twitter.com/docs/cards/types/summary-card
 - Validator Tool https://dev.twitter.com/docs/cards/validation/validator


