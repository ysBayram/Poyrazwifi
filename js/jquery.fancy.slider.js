/*
 * jQuery Fancy Slider v0.1
 * http://srodek.info
 *
 * Copyright 2012, Michał Środek
 * Free to use and abuse under the MIT license.
 * http://www.opensource.org/licenses/mit-license.php
 * 
 * March 2012
 */

(function($) {
	
	$.fn.fancySlider = function(options){

		var parent = this;

		//Defaults are below
		var settings = $.extend({}, $.fn.fancySlider.defaults, options);
		var currentSlide = 0;
		var animation = false;
		var allSlides = $('.fancyslider-slides>div', parent).length;
		
		var imgArr = [];

		$('.fancyslider-slides>div', parent).each(function(){
			var t = $(this).css('background-image');
			if(t!='') {
				t = t.substring(4,t.length-1);
				if(t[0] == '"')
					t = t.substring(1,t.length-1);
				imgArr.push(t);
			}

			var t = $('.fancyslider-image', $(this));
			if(t.length==1) {
				t = t.css('background-image');
				t = t.substring(4,t.length-1);
				if(t[0] == '"')
					t = t.substring(1,t.length-1);
				imgArr.push(t);
			}
		});

		var imgList = [];
		var counter = 0;

		for(var i=0; i<imgArr.length; i++) {
			$("<img />").attr("src", imgArr[i]).load(function() {
				counter++;
				if(counter==imgArr.length) {

					$('.fancyslider-next, .fancyslider-prev, .fancyslider-slides>div:first-child',parent).add('.fancyslider-bullets.fancyslider-loading',parent.parent().parent()).animate({opacity:1}, 1400, function() {
					
						$(this).removeClass('fancyslider-loading');
						
					});

				}
			});
		}
		
		function changeSlide(actual, next){
			if(animation) return false;
			
			animation = true;
			settings.beforeChange(actual, next);
			
			var slide = $('.fancyslider-slides>div', parent).eq(actual);

			$('.fancyslider-bullets a.active').removeClass('active');
			$('.fancyslider-bullets a').eq(next).addClass('active');
			
			$('.fancyslider-image, .fancyslider-content', slide).animate({left:'150%'}, {duration:400});

				slide.delay(400).animate({opacity:0});

				slide = $('.fancyslider-slides>div', parent).eq(next);
				currentSlide = next;
				
//				$('.fancyslider-bullets a', parent.parent().parent()).removeClass('active');
//				$('.fancyslider-bullets a', parent.parent().parent()).eq(next).addClass('active');
				
				$('.fancyslider-content h1', slide).stop().css({marginTop:'-460px'});
				if($('.fancyslider-content-right', slide).length==0)
					$('.fancyslider-content .fancyslider-button', slide).stop().css({marginLeft:'-760px', opacity:0});
				else
					$('.fancyslider-content .fancyslider-button', slide).stop().css({width:'450px', marginLeft:'760px', opacity:0});

				$('.fancyslider-content p.fancyslider-text', slide).stop().css({marginTop:'760px'});
				
				slide.css({display:'block', opacity:0}).stop().animate({opacity:1}, function(){
					
					$('.fancyslider-image', $(this)).css({left:'-1200px'}).animate({left:0}, 400);
					$('.fancyslider-content', $(this)).css({left:0});
					
					$('.fancyslider-content h1', $(this)).stop().delay(400).animate({marginTop:0}, 200);
					
					$('.fancyslider-content p.fancyslider-text', $(this)).stop().delay(550).animate({marginTop:0}, 400);
					$('.fancyslider-content .fancyslider-button', $(this)).stop().delay(800).animate({opacity:1, marginLeft:0}, 300);
					
					$('.fancyslider-slides>div', parent).css('z-index', 1);
					$(this).css({'z-index': 2, opacity:0}).animate({opacity:1});
					animation = false;
				});
			return false;
		}
	
		$('.fancyslider-next', parent).click(function(){
			if(animation) return false;

			var next = currentSlide+1;
			if(next == allSlides) next = 0;
			changeSlide(currentSlide, next);
		});
		
		$('.fancyslider-prev', parent).click(function(){
			if(animation) return false;

			var next = currentSlide-1;
			if(next == -1) next = allSlides-1;
			changeSlide(currentSlide, next);
		});
		
		$('.fancyslider-bullets a', parent.parent().parent()).click(function(){
			if(animation) return false;
			if(currentSlide == $(this).index()) return false;
			
			changeSlide(currentSlide, $(this).index());
		})
		
		var auto = true;
		
		var autoTransition = setTimeout(function(){makeAutoTransition()}, settings.pauseTime);

		function makeAutoTransition(){
			if(animation) return false;

			var next = currentSlide+1;
			if(next == allSlides) next = 0;
			changeSlide(currentSlide, next);
			autoTransition = setTimeout(function(){makeAutoTransition()}, settings.pauseTime);

		}
		
		
		$('.fancyslider-boxed').mouseenter(function(){
			auto = false;
			clearTimeout(autoTransition);
		});
		
		$('.fancyslider-boxed').mouseleave(function(){
			auto = true;
			autoTransition = setTimeout(function(){makeAutoTransition()}, settings.pauseTime);
		});
		
	};


	//Default settings
	$.fn.fancySlider.defaults = {
		pauseTime: 4000,
		beforeChange: function(){}
	};
	
	
})(jQuery);