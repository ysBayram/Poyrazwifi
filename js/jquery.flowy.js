/**
 * Flowy 1.0
 * Copyright (C) by Michał Środek
 * All rights reserved
 * http://srodek.info
 */

;(function($) {
	$.fn.flowy = function(options){
		var options = $.extend({}, $.fn.flowy.defaults, options);

		return this.each(function() {
			var duringAnimation = false;
			var selectedSet = 'gallery-all';
			var parentObject = $(this);
			var itemsContainer = $(this).find('>div');
			var galleryItems = itemsContainer.find('>div'); // '.gallery-item',parentObject);
			var itemWidth = 10;
			var itemHeight = 10;
			
			for(var i=0; i<galleryItems.length; i++) {
				var j = galleryItems.eq(i).outerWidth()+options.margin;
				var k = galleryItems.eq(i).outerHeight();//+options.margin;
				if(j>itemWidth) itemWidth=j;
				if(k>itemHeight) itemHeight=k;
			}
			
			var columns = Math.floor((parseInt(itemsContainer.css('width'))+options.margin)/itemWidth);

			function changeGroup(newItemsClass, animateContener) {
				
				$('.flowy-clone').remove();
				galleryItems.css({'z-index':1});
				
				selectedSet = newItemsClass;
				duringAnimation = true;
				$('.gallery-splitter .selected').removeClass('selected');
				$('.'+newItemsClass).addClass('selected');
				if(newItemsClass=='gallery-all')
					var newItems = galleryItems;
				else {
					var newItems = $('.'+newItemsClass).not('.gallery-splitter .'+newItemsClass);
				}
			
				var tempElements = galleryItems.not('.flowy-hidden');
				newItems.css({'z-index': 3});
				var t=0;
				var l=0;
				for(var i=0; i<newItems.length; i++) {

					if(animateContener) {
						var item =$(newItems).eq(i);
						if(item.hasClass('flowy-hidden')) {
							tempElements.each(function() {
								var pos = $(this).position();
								if(pos.left == l && pos.top == t+5) {
									var cloned = $(this).clone().addClass('flowy-clone').css({display: 'block'}).removeClass('.flowy-hidden').css({'z-index' : 2});
									$('.image-description', cloned).remove(); // fix text issue
									itemsContainer.append(cloned);
								}
								else
									tempElements = tempElements.not($(this));
							});
							item.removeClass('.flowy-hidden').css({display: 'block', opacity: 0, left: l, top: t+5}).stop().animate({'opacity':1},{ duration: options.animationSpeed, queue: false, complete: function(){ if(typeof(cloned)!="undefined") cloned.remove(); }},options.easing);
						}
						else
							item.css({display: 'block'}).removeClass('.flowy-hidden').stop().animate({left: l, top: t+5},options.animationSpeed,options.easing);
					}
					else
						$(newItems).removeClass('flowy-hidden').eq(i).css({left: l, top: t+5});
					
					l+=itemWidth;
					if((i+1)%columns==0) {
						l = 0;
						t += itemHeight;
					}
				}
				newItems.removeClass('flowy-hidden');
				itemsContainer.find('>div').not(newItems).stop().animate({'opacity':0},{ duration: options.animationSpeed, queue: false, complete: function(){ $(this).css({display: 'none'}).addClass('flowy-hidden'); portfolioAnimations(); duringAnimation = false; } },options.easing);

				if(animateContener) {
					var newHeight = 5+itemHeight*Math.ceil(newItems.length/columns);
					if(parentObject.next().length==0) newHeight-=20;

					itemsContainer.stop().animate({height:newHeight}, { duration: options.animationSpeed, queue: false }, options.easing, function(){ duringAnimation = false; });
					
				}
				else{
					var newHeight = 5+itemHeight*Math.ceil(newItems.length/columns);
					if(parentObject.next().length==0) newHeight-=20;
					
					itemsContainer.css({height:newHeight});
					portfolioAnimations();
					duringAnimation = false; 
				}
			}

			$('.gallery-splitter a', parentObject).click(function(){
				if(duringAnimation == false)
					changeGroup(this.hash.slice(1), true);
			});

			changeGroup(window.location.hash.slice(1)=='' ? 'gallery-all' : window.location.hash.slice(1), false);
		});
	};

	$.fn.flowy.defaults = {
		animationSpeed: 700,
		easing: 'easeOutSine',
		margin: 0
	}
})(jQuery);