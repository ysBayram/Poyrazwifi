<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="comments.ascx.cs" Inherits="WebPortal_v1.user_controls.comments" %>

<div id="comments">

    <h4><span class="comments-number">3</span> Yorum/Cevap Bölümü</h4>

    <ul id="comment-list" class="invent-comments-list">
        <li>
            <img class="avatar" src="images/user.jpg" alt="avatar" />

            <div class="comment-text">

                <div class="corner"></div>
                <h6 class="comment-author">Nick Bruhner</h6>
                <a href="#" class="right reply"><span>Reply</span></a>
                <div class="clear"></div>

                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum nibh eros, dolor vestibulum eu dapibus eget, volutpat et magna. Maecenas id turpis laoreet elit consectetur tempus. Quisque eget mi porta magna fermentum iaculis.
                </p>
            </div>
        </li>

        <li>
            <ul class="children">
                <li>
                    <img class="avatar" src="images/user.jpg" alt="avatar" />
                    <div class="comment-text">
                        <div class="corner"></div>
                        <h6 class="comment-author">Nick Bruhner</h6>
                        <a href="#" class="right reply"><span>Reply</span></a>
                        <div class="clear"></div>

                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum nibh eros, dolor vestibulum eu dapibus eget, volutpat et magna. Maecenas id turpis laoreet elit consectetur tempus. Quisque eget mi porta magna fermentum.
                        </p>
                    </div>
                </li>
            </ul>
        </li>

        <li>
            <img class="avatar" src="images/user.jpg" alt="avatar" />
            <div class="comment-text">
                <div class="corner"></div>
                <h6 class="comment-author">Nick Bruhner</h6>
                <a href="#" class="right reply"><span>Reply</span></a>
                <div class="clear"></div>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum nibh eros, dolor vestibulum eu dapibus eget, volutpat et magna. Maecenas id turpis laoreet elit consectetur tempus. Quisque eget mi porta magna fermentum iaculis.
                </p>
                <div class="clear"></div>
            </div>
        </li>

    </ul>

    <h4>Yorum/Cevap Yolla!</h4>
    <p>
        Your email address will not be published. Required fields are marked *
    </p>
    <div id="respond" class="invent-respond column-3-4">
        <label><strong>İsim</strong></label>
        <em class="err-message">*required</em>
        <br />
        <div class="around-input-background">
            <div class="around-input-border">
                <input type="text" name="name" id="invent-name-contact" value="" class="white-input-decoration white-focus-decoration full-width required" />
            </div>
        </div>

        <label><strong>E-mail</strong></label>
        <div class="around-input-background">
            <div class="around-input-border">
                <input type="text" name="name" id="invent-email-contact" value="" class="white-input-decoration white-focus-decoration full-width" />
            </div>
        </div>

        <label><strong>Mesaj</strong></label>
        <em class="err-message">*required</em>
        <br />
        <div class="around-textarea-background">
            <div class="around-textarea-border">
                <textarea name="message" id="message" class="white-textarea-decoration white-focus-decoration required" rows="12" cols="10"></textarea>
            </div>
        </div>

        <input type="submit" value="Gönder" class="invent-button invent-button-default left" />
    </div>
    <div class="clear"></div>

</div>
