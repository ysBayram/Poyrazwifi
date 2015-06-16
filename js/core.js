//Script to facebook like Button
(function(d, s, id) {
	  var js, fjs = d.getElementsByTagName(s)[0];
	  if (d.getElementById(id)) return;
	  js = d.createElement(s);js.id = id;
	  js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
	  fjs.parentNode.insertBefore(js, fjs);
	}(document, 'script', 'facebook-jssdk'));

//Script to tweeter follow Button
!function(d,s,id){
	var js,fjs=d.getElementsByTagName(s)[0];
	if(!d.getElementById(id)){
		js=d.createElement(s);
		js.id=id;
		js.src="//platform.twitter.com/widgets.js";
		fjs.parentNode.insertBefore(js,fjs);
	}}(document,"script","twitter-wjs");

//Script to google+ Button
(function() {
	var po = document.createElement('script');po.type = 'text/javascript';po.async = true;
	po.src = 'https://apis.google.com/js/plusone.js';
	var s = document.getElementsByTagName('script')[0];s.parentNode.insertBefore(po, s);
})();


function portfolioAnimations(){

	var $ = jQuery;
	
	var items = $('a[data-fancybox]').not('.external');

	items.each(function(){
		if($(this).parent().parent().hasClass('flowy-hidden'))
			items = items.not($(this));
	});
	
	items.fancybox({
			'padding'       : 5,
			'transitionIn'      : 'fade',
			'transitionOut'     : 'fade',
			'speedIn'       : 450,
			'centerOnScroll'    : false,
			'speedOut'      : 300,
			'cyclic'        : true,
			'autoScale'         : true,
			'overlayColor'      : '#0f0f0f',
			'overlayOpacity'    : 0.95,
			'titlePosition'     : 'outside',
			'onStart'			: function(){
				if ( !$.browser.msie || $.browser.version == '9.0'){
					$('.image-hover, .image-hover-icon').fadeTo(0,0);
				}
				else{
					$('.image-hover').fadeTo(0,0);
					$('.image-hover-icon').css('display','none');
				}
			},
			'onComplete' : function() {
				if( $('#fancybox-content iframe').length>0 )
					$('#fancybox-content').css({zIndex: 1103});
				else
					$('#fancybox-content').css({zIndex: 1102});
				return true;
			},
			'titleFormat': function(title, currentArray, currentIndex, currentOpts) {
				return '<span style="position:absolute; width:80%;">'+(title.length ? '' + title : '')+'</span><span style="position:absolute;right:25px">'+(currentIndex + 1) + ' / ' + currentArray.length +  '</span>';
			}
		});
}

function relative_time(time_value) {
  var values = time_value.split(" ");
  time_value = values[1] + " " + values[2] + ", " + values[5] + " " + values[3];
  var parsed_date = Date.parse(time_value);
  var mydate = new Date(parsed_date);
  var month = 1+mydate.getMonth();
  if(month<10) month = '0'+month;
  var day = mydate.getDate();
  if(day<10) day = '0'+day;
  return mydate.getFullYear()+'-'+month+'-'+day;
}

jQuery(function($) {	
	
	$('.no-js').each(function(){
		$(this).removeClass('no-js');
	})
	
	$('ul.sf-menu').superfish({autoArrows: true});
	
	
	$('.js-center').each(function(){
		var itemWidth= $(this).css('width');
		var wrapperWidth= $(this).parent().css('width');
		var marginLeft= (wrapperWidth.replace('px', '') - itemWidth.replace('px', '')) / 2;
		$(this).css({"margin-left": marginLeft});
	})

	$('.invent-hover-text').each(function(i){
		var textHeight= $(this).css('height');
		var imageHeight= $(this).parent().css('height');
		var topMargin= (imageHeight.replace('px', '') - textHeight.replace('px', '')) / 2;
		$(this).css({top: topMargin});
	})
	
	
	$('.invent-hover-2').hover(function(){		
		$('.flickr-hover-arrow',this).stop().animate({
			'left': '50%',
			'margin-left': '-13px'
		}, {
			queue: false,
			easing: 'easeOutBack',
			duration: 500
		});
	}, function(){
		$(".flickr-hover-arrow",this).stop().animate({
			left: "-60px"
		},{
			queue:false,
			duration:200
		});
	})
	
	$('#sidebar .widget_flickr a').hover(function(){		
		$('.flickr-hover-arrow',this).stop().animate({
			'left': 17
		}, {
			queue: false,
			easing: 'easeOutBack',
			duration: 500
		});
	}, function(){
		$(".flickr-hover-arrow",this).stop().animate({
			left: "-50px"
		},{
			queue:false,
			duration:200
		});
	})
	
	if(!$.browser.mozilla) {
		function handleScroll() {
			if($("#background.scrollable").length){
				$("#background.scrollable").css("backgroundPosition", "left "+ $(window).scrollTop()*-.1+"px");
				$("#background-front").css("backgroundPosition", "left "+ $(window).scrollTop()*-.3+"px");
			}
		}

		$(window).bind({ scroll : handleScroll });
		handleScroll();
	}

	
    if(typeof($.fn.flowy)!='undefined') {
		$('.invent-gallery').flowy({margin:20});
		portfolioAnimations()
		$('#widgets-container .widget_flickr>ul>li a img').load(function() {
			$('#widgets-container .widget_flickr>ul>li').css({background: 'transparent'});
		});
	}
	
	$('input[type="text"], textarea').click(function() {
        if (this.value == this.defaultValue){
        	this.value = '';
    	}
        if(this.value != this.defaultValue){
        }
    });
	
    $('input[type="text"], textarea').blur(function() {
      if (this.value == ''){
        	this.value = (this.defaultValue ? this.defaultValue : '');
    	}
    });
	
	$('.white-focus-decoration').focus(function(){
		$(this).add($(this).parent()).addClass('white-form-el-focus');
	}).blur(function(){
		$(this).add($(this).parent()).removeClass('white-form-el-focus');
	});
	
	
	$('#contact-form').submit(function(){

		var error = 0;
		
		var elements = $('input[type="text"].required, textarea.required', this);
		elements.removeClass('white-form-el-error');
		var tmp = elements.parent().removeClass('around-input-border-error');
		tmp.parent().removeClass('around-input-background-error');
		$('.err-message').removeClass('show-error');
		
		elements.each(function(){
			var itemError = 0;
			if(this.value == this.defaultValue || this.value=="") {
				itemError = 1;
				
			}
			else{

				if($(this).attr('id')=='invent-email-contact') {
					if(!(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test($(this).val()))) {

						itemError = 1;
					}

				}
			}
			if(itemError){
				$(this).addClass('white-form-el-error');
				$(this).parent().addClass('around-input-border-error');
				$(this).parent().parent().addClass('around-input-background-error');
				$(this).parent().parent().prev().prev().addClass('show-error');
				error = 1;
			}
		});

		if(!error){
			$.post(
				$('#contact-form').attr('action'), {
					name: $('#invent-name-contact').val(),
					email: $('#invent-email-contact').val(),
					message: $('#message').val(),
					recaptcha_challenge_field: $('*[name="recaptcha_challenge_field"]').val(),
					recaptcha_response_field: $('input[name="recaptcha_response_field"]').val()
				},
				function(response) {
					if(response.captchaerror){
						alert('Captcha error! Please refresh captcha and type generated words again.');
					}
					else{
						var msg = $('<p>'+response.message+'</p>').hide().fadeIn(1500);
						$('#contact-form>*, .contact-form-header').css({display: 'none'});

						if(response.error)
							$('#form-response-false').append(msg).css({display: 'block'});
						else
							$('#form-response-success').append(msg).css({display: 'block'});
					}
				},
				'text json'
			);
		}
		
		return false;
	});
	
    $('.acc-style-example').click(function () {
            $('.acc-style-example strong').animate({rotate: '+=120deg'}, 0);
    });
	
	$('.scroll-to-top, .scroll-to-top-text').click(function(){
			$.scrollTo(0,500);
			return false;
		});
	
	if ((!$.browser.msie || $.browser.version != "6.0") && typeof($.fn.tipTip)!='undefined') {
		$(".invent-social-list-el, .scroll-to-top").tipTip({
            defaultPosition: "top",
            edgeOffset: 5
        });
    }
	
	var inventSliderConfig = {
		effect: 'random',
		slices:  '10',
		animSpeed: '200', // transition speed
		pauseTime: '5000',
		captionOpacity: '0.6',
		directionNav: 'on',
		controlNav: 'on',
		bgcolors: ['#e9e9e9', '#0e0e0e', '#eeeeee', '#0f1922']
            };

	var nivoSliderConfig = {
		effect: 'random',
		slices:  '20',
		animSpeed: '1200', // transition speed
		pauseTime: '5000',
		captionOpacity: '0.7',
		directionNav: 'on',
		controlNav: 'on'
            };
			
	if(typeof(jQuery.anythingSlider)!='undefined'){
		
		$('.any-slider').each(function(i){
		
		$(this).anythingSlider({
			width : 940,
			height: 380,
			resizeContents: true,
			theme : 'minimalist-round',
			resumeOnVideoEnd: false,
			resumeOnVisible: true
		});
		}).anythingSliderFx({
		   // base FX definitions
		   // '.selector' : [ 'effect(s)', 'size', 'time', 'easing' ]
		   // 'size', 'time' and 'easing' are optional parameters, but must be kept in order if added
			'.quoteSlide'         : [ 'top', '500px', '1000', 'easeOutElastic' ],
			'.expand'             : [ 'expand', '10%', '400', 'easeOutBounce' ],
			'.textSlide h3'       : [ 'top fade', '200px', '500', 'easeOutBounce' ],
			'.textSlide img,.fade': [ 'fade' ],
			'.textSlide li'       : [ 'listLR' ]
		});
		
		$('.anythingSlider').each(function(i){
			var controlNav= $('.thumbNav', this).css('width');
			var sliderWidth= $(this).css('width');
			var leftMargin= (sliderWidth.replace('px', '') - controlNav.replace('px', '')) / 2;
			$('.thumbNav', this).css({marginLeft: leftMargin});

		})	
	}

	
	$('.nivoSlider').each(function(i){

		var $$ = $(this);
		if($$.hasClass('invent-slider')) {
			
			$$.parent().parent().css({backgroundColor: inventSliderConfig.bgcolors[0]});

			inventSliderConfig.effect = 'fade';
			inventSliderConfig.beforeChange = function(){

					var slideId = $$.data('nivo:vars').currentSlide;

					if (slideId<0) slideId += inventSliderConfig.bgcolors.length;
						slideId+=1
					if(slideId == inventSliderConfig.bgcolors.length) slideId=0;

					$('#invent-slider-background').css({opacity:0, backgroundColor: inventSliderConfig.bgcolors[slideId]});
					
					var curr = $$.data('nivo:vars').currentSlide;
					var last = $$.data('nivo:vars').lastSlide;

					$('.slider-box.actual', $$.parent()).stop().animate({opacity:0},
					{
						easing: 'easeOutSine',
						duration: 'inventSliderConfig.animSpeed',
						queue: false,
						complete: function(){
							$(this).removeClass('actual');
						}
					});
						
			};

			inventSliderConfig.afterChange = function(){
					$('.invent-slider-container').css({backgroundColor: $('#invent-slider-background').css('backgroundColor')});

						var curr = $$.data('nivo:vars').currentSlide;
						var last = $$.data('nivo:vars').lastSlide;
						var newSliderBox = $('.slider-box', $$.parent()).eq(curr).addClass('actual');

						var slideTitle = $('.slide-title', newSliderBox);
						var slideContent = $('.slide-content', newSliderBox);

						newSliderBox.css({height: slideTitle.outerHeight()+slideContent.outerHeight()+10});

						slideContent.css({top:460, opacity:0});
						slideTitle.css({opacity:0, top: -460}).stop().animate({opacity:1, top:13},{easing: 'easeInSine', duration:inventSliderConfig.animSpeed, queue: false});
						slideContent.animate({opacity:0},{duration:100, queue: false, complete:function(){
							$(this).animate({opacity:1, top:slideTitle.outerHeight()+19},{easing: 'easeInSine', duration:inventSliderConfig.animSpeed});
						}});
						newSliderBox.animate({opacity:1},{duration:inventSliderConfig.animSpeed, queue: false})
			};
			
			inventSliderConfig.afterLoad = function(){
						var newSliderBox = $('.slider-box', $$.parent()).eq(0).addClass('actual');

						var slideTitle = $('.slide-title', newSliderBox);
						var slideContent = $('.slide-content', newSliderBox).css({top:460, opacity:0});
						newSliderBox.css({height: slideTitle.outerHeight()+slideContent.outerHeight()+10});

						slideTitle.css({top: -460, opacity:0}).animate({top:13, opacity:1},{easing: 'easeInSine', duration:inventSliderConfig.animSpeed, queue: false});
						slideContent.animate({opacity:0},{duration:100, queue: false, complete:function(){
							$(this).animate({opacity:1, top:slideTitle.outerHeight()+19},{easing: 'easeInSine', duration:inventSliderConfig.animSpeed, queue: false});
						}});
						newSliderBox.animate({opacity:1},{duration:inventSliderConfig.animSpeed, queue: false})
						
						$('.slider-box', $$).mouseenter(function(){
							$$.data('nivo:vars').stop = true;

						});
						$('.slider-box', $$).mouseleave(function(){
							$$.data('nivo:vars').stop = false;

						});
					}
					
			$(this).nivoSlider(inventSliderConfig);		
		} else
			$(this).nivoSlider(nivoSliderConfig);
		
		var sliderWidth= $(this).width();
		
		if($$.hasClass('invent-slider')) {
			var controlNavigation = $('.nivo-controlNav', $$.parent().parent().parent());
			sliderWidth = controlNavigation.parent().width();
 		}
		else {
			var controlNavigation = $('.nivo-controlNav', $$);
		}
		
		var controlNavWidth= controlNavigation.width();
		controlNavigation.css({width: controlNavWidth, left: (sliderWidth - controlNavWidth) / 2});

		var arrowHeight= $('.nivo-prevNav', this).height();
		var sliderHeight= $(this).height();
		var topMargin= (sliderHeight - arrowHeight) / 2;
		$('.nivo-prevNav', this).css({top: topMargin});
		$('.nivo-nextNav', this).css({top: topMargin});
		
	})
		

	if ( !$.browser.msie || $.browser.version == '9.0'){

		$('.image-hover, .image-hover-icon').fadeTo(0,0);

			$('.image-hover-icon').hover(function(){
				$(this).prev().stop().fadeTo(600,0.5);
				$(this).stop().fadeTo(600,1);
			},function(){
				$(this).add($(this).prev()).stop().fadeTo(600, 0);
			});
		}
	else if($.browser.version != '6.0') { /* IE 7 and 8 */
		$('.image-hover').fadeTo(0,0);
		$('.image-hover-icon').css('display','none');
		$('.image-hover').hover(function(){
			$(this).stop().fadeTo(600,0.5);
			$(this).next().css('display','block');
		},function(){
			$(this).next().css('display','none');
		});

		$('.image-hover-icon').hover(function(){
			$(this).css('display','block');
		},function(){
			$(this).css('display','none');
			$(this).prev().stop().fadeTo(600, 0);
		});
	}

	// portfolioAnimations();
		if(typeof(jQuery.flowy)!='undefined')
			$('.invent-gallery').flowy({margin:20});



	var config = {
		container: '.invent-accordion', //.acc-style1, .acc-style2',
		tab: '>div>h3',
		content: '>div>.acc-content'
	}


	$(config.container).each(function(){
		var c = $(this);

		$(config.tab,c).each(function(i){
			var d = $(this).next();
			var title = this;
			
			function doAnimation(title){
					if(d.height()>0){
						var h = 0;

					} else {

						if(!d.is(':animated')) {
							d.css('display','block');
							d.height('auto');
							var h = d.height();
							d.height(0);
						}
					}

					d.stop().animate({
						'height':h
					},'600', function(){
						if(h==0)
							$(this).css({display:'none'});
					});

					if(h>0)
						$(title).addClass('active');
					else
						$(title).removeClass('active');
			}
							
			if($(this).hasClass('active')){
				doAnimation(title);
			} else
				$(this).next().css('display','none');
			
			$(this).click(function(){

				if(c.hasClass('invent-strict-accordion') && $('.active',c).length){
					var a = $('.active',c);
					if(activeIndex = a.parent().index() == $(title, c).parent().index()){
						doAnimation(title);
					} else {
					
						a.removeClass('active').next().stop().animate({
							'height':0
						},'600', function(){
							$(this).css('display','none');
							doAnimation(title);
						});
					}
				}
				else
					doAnimation(title);

			});

		});

	});
	if(typeof(jQuery.tools)!='undefined') {
		$.tools.tabs.addEffect("accSlide", function(tabIndex, done) {

                       var panes = this.getPanes();
                       var $$ = panes.eq(tabIndex);
                       var parentNode = $$.parent();
                       var h = $$.height();

                       if(parentNode.height()>h) {

                               panes.stop().css({zIndex:1}).animate({
                                       opacity:0
                               },400);
                               $$.stop().css({zIndex:2}).animate({
                                       opacity:1
                               }, 400, function(){
                                       parentNode.stop().animate({
                                               height: h
                                       }, 400);
                               });
                       } else {
                               parentNode.stop().animate({
                                       height: h
                               }, 400, function(){
                                       panes.stop().css({zIndex:1}).animate({
                                               opacity:0
                                       },400);
                                       $$.stop().css({zIndex:2}).animate({
                                               opacity:1
                                       }, 400);
                               });
                       }
                       done.call();
               });

		$(".invent-tabs").each(function(){
			$('ul', this).tabs($('.invent-panes>div', this), {
				effect:	'accSlide', 
				current: 'current'
			});
		});
	}
	

//	CAROUSEL__________________

$('.jcarousel-skin-horizontal1.hidden').removeClass('hidden');
	$('.jcarousel-skin-horizontal1').each(function(carouselId){
		var $$=$(this);
		var $container =  $$.parent().parent();

		$('a[data-fancybox]', $$).not('.external').attr('data-fancybox', 'carousel-images-'+carouselId).fancybox({
			'padding'       : 5,
			'transitionIn'      : 'fade',
			'transitionOut'     : 'fade',
			'speedIn'       : 450,
			'centerOnScroll'    : false,
			'speedOut'      : 300,
			'cyclic'        : true,
			'autoScale'         : true,
			'overlayColor'      : '#0f0f0f',
			'overlayOpacity'    : 0.95,
			'titlePosition'     : 'outside',
			'onStart'			: function(){
				if ( !$.browser.msie || $.browser.version == '9.0'){
					$('.image-hover, .image-hover-icon').fadeTo(0,0);
				}
				else{
					$('.image-hover').fadeTo(0,0);
					$('.image-hover-icon').css('display','none');
				}
			},
			'titleFormat': function(title, currentArray, currentIndex, currentOpts) {
				return '<span style="position:absolute; width:80%;">'+(title.length ? '' + title : '')+'</span><span style="position:absolute;right:25px">'+(currentIndex + 1) + ' / ' + currentArray.length +  '</span>';
			},
			'onComplete' : function() {
				if( $('#fancybox-content iframe').length>0 )
					$('#fancybox-content').css({zIndex: 1103});
				else
					$('#fancybox-content').css({zIndex: 1102});
				return true;
			}
		});

		
		// IE7/IE8 fix
		$('li:last-child', $$.not('.testimonials-carousel')).not('.jcarousel-paginator li').css('padding-right', 0);

		var options = {
			scroll: 2,
			animation: 310,
			easing: 'easeInOutQuad'
		};

		options.buttonNextCallback = function(instance, elem, flag){
		//	var controls = instance.container.parent().prev();
			if(flag)
				$('.jcarousel-next', $container).removeClass('disabled');
			else
				$('.jcarousel-next', $container).addClass('disabled');
		};
		options.buttonPrevCallback = function(instance, elem, flag){
		//	var controls = instance.container.parent().prev();
			if(flag)
				$('.jcarousel-prev', $container).removeClass('disabled');
			else
				$('.jcarousel-prev', $container).addClass('disabled');
		};

		// testimonials
		if($$.hasClass('testimonials-carousel')) {

			options.auto = 5;
			options.wrap = 'circular';
			options.scroll = 1;
			options.animation = 500;
			options.easing = 'easeInOutQuart';
		}

		var size = $('>li', $$).length;
		
		options.itemFirstInCallback = {
			onBeforeAnimation: function(instance, li, n) {
				var paginator = $('.jcarousel-paginator', instance.container);
				var items = $('li', paginator);

				items.removeClass('active');
				items.eq(n%size-1).addClass('active');

				$('.jcarousel-clip li', instance.container).css({display: 'block'});
				var clip = $('.jcarousel-clip', instance.container);
				var h = 0; // $('li', clip).eq(n%size-1).height();
				
				var start = n%size-1;
				var remainingWidth = clip.width();
				$('li', clip).each(function(){
					if($(this).index() >= start && remainingWidth-$(this).outerWidth()>=0) {
						if($(this).height() > h) h = $(this).height();
						
						remainingWidth -= $(this).outerWidth();
					}
				});
				
				h+=10-h%10;
				
				if(h<110) h = 110;

				clip.stop().animate({'height': h}, 1000); // .add('.jcarousel-left-decorator, .jcarousel-right-decorator',instance.container)
			}
		}

		// running carousel
		$$.jcarousel(options);
		var instance = $(this).data('jcarousel');

			var container = $$.parent().parent();
			var clip = $('.jcarousel-clip', container)
			var h = $('li', clip).eq(0).outerHeight();
			h += 10-h%10;
			if(h<110) h = 110;
			
			clip.stop().css({'height': h});

			$('.jcarousel-prev',$container).click(function(){
				instance.prev();
		        return false;
			});

			$('.jcarousel-next',$container).click(function(){
				instance.next();
		        return false;
			});

	});
	


	function refreshFadeCarousel($,twitter){
		$('.fade-carousel').not('.fade-carousel-running').each(function(){

			
			if($('.fade-carousel-controls a', this).length!=0) return false;
			
			var elements = $('ul>li',this);
			var allElements = elements.length;

			for( var i=0; i<allElements; i++){
				$('.fade-carousel-controls', this).append($('<a href="#"></a>'));
			}

			$('.fade-carousel-controls a:first-child', this).addClass("actual");

			var actual = 0;
			elements.hide();
			elements.eq(0).show();

			$('.carousel-next',this).click(function(){
				if(elements.eq(counter).filter(':animated').length) return false;
				elements.eq(counter).fadeOut(100, function(){
					counter++;
					if(counter==allElements) counter = 0;
					elements.eq(counter).fadeIn(100);
				});
				return false;
			});

			$('.fade-carousel-controls a', this).click(function(){
				if(elements.eq(actual).filter(':animated').length) return false;
				var i = $(this).index();

				var controlsContainer = $(this).parent();
					$('.actual', controlsContainer).removeClass("actual");
					elements.eq(actual).fadeOut(100, function(){
					actual = i;
					$('a', controlsContainer).eq(actual).addClass("actual");
					elements.eq(actual).fadeIn(100);
				});
				return false;

			});

			$('.carousel-prev',this).click(function(){
				if(elements.eq(counter).filter(':animated').length) return false;
				elements.eq(counter).fadeOut(100, function(){
					counter--;
					if(counter==-1) counter = allElements-1;
					elements.eq(counter).fadeIn(100);
				});
				return false;
			});
			
			$(this).addClass('fade-carousel-running');
		});		
	}

	refreshFadeCarousel($);


//	Twitter data

	$('.twitter-data').each(function(){
		var user = $('input[name="user"]',this).val();
		var number = $('input[name="number"]',this).val();
		
		var container = $(this).parent();
		
		container.append($('<div></div>').html('Loading...'));
		$(this).remove();
		$.ajax({
			url: 'https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name='+user+'&count='+number,
			method: 'get',
			success: function(twitters){
				
				$('div', container).remove();
				var list = $('<ul></ul>');
				container.parent().next().attr('href', 'http://twitter.com/#!/'+user);

				for (var i=0; i<twitters.length; i++){
					var username = twitters[i].user.screen_name;
					var status = twitters[i].text.replace(/((https?|s?ftp|ssh)\:\/\/[^"\s\<\>]*[^.,;'">\:\s\<\>\)\]\!])/g, function(url) {
						return '<a href="'+url+'" class="twitter-link schemehovercolor">'+url+'</a>';
					}).replace(/\B@([_a-z0-9]+)/ig, function(reply) {
						return  reply.charAt(0)+'<a href="http://twitter.com/'+reply.substring(1)+'" class="twitter-link schemehovercolor">'+reply.substring(1)+'</a>';
					});

					status = '<p>' + status+'</p>';
					list.append($('<li></li>')
							.append(status));
							
				}

				container.append(list);
				container.parent().addClass('fade-carousel');

				refreshFadeCarousel($);

			},
			error: function(xhrObject, textStatus){
				$('div', container).remove();
				var message = $('<div></div>').html('Connection problem. Check twitter widget configuration...').hide().fadeIn();
				container.append(message);
			},
			timeout: 30000,
			dataType: "jsonp"
		});
	});

	$('#no-link').click(function(){
		 event.preventDefault();
		 return false;
	});
	
	if(typeof($.fn.slidedeck)!='undefined') {
		$('.slidedeck').slidedeck();
	}
	// SLIDE DECK The most basic implementation using the default options
	

	/* MENU */
	$('#nav>li').each(function(){
		$(this).append($('<div></div>').addClass('nav-decorator').append('<div></div>'));
	});
	
	$('#nav>li').not('#nav>li.current').hover(function(){
		$('.nav-decorator', $(this)).stop().animate({bottom: '-30px', opacity:1});
	}, function(){
		$('.nav-decorator', $(this)).stop().animate({bottom: '-35px', opacity:0});
	})
	
	
	/* obracane plus i minus */
	
	$("#plus-image").click( function(){
		$(this).rotate({
			angle: 0, 
			animateTo:90
		})
	});
	
	$("#minus-image").click( function(){
		$(this).rotate({
			angle: 180, 
			animateTo:0
		})
	});



});


