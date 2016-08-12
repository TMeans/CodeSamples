<asp:Content ID="Content1" ContentPlaceHolderID="head_pre" runat="Server">
    <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal>
    <style type="text/css">
        input.ng-dirty.ng-valid
		{
            border-color:#007454;
            background-color:rgba(0, 116, 84,.05);
        }

        input.ng-invalid.ng-dirty, .invalid
		{
            border-color:#FF0000;
            background-color:rgba(255, 0, 0,.05);
        }

        input, textarea
		{
            border-radius:0 !important;
        }
		
        .grey-button 
		{		
			background-color:#808080 !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head_post" runat="Server">
	<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.3.15/angular.js"></script>
	<script src="/about/team/tell-a-friend/tell-a-friend.js?v=2"></script>
	<script>
	
		//masks email addresses from web crawlers
        function CryptMailto(e, name) {
            var n = 0;
            var r = "";
            var s = "mailto:" + e;
            e = e.replace(/@/, " [at] ");
            e = e.replace(/\./g, " [dot] ");


            for (var i = 0; i < s.length; i++) {
                n = s.charCodeAt(i);
                if (n >= 8364) {
                    n = 128;
                }
                r += String.fromCharCode(n + 1);
            }
            //  document.forms[0].cyptedEmailField.value = r;

            document.write("<a href=\"javascript:linkTo_UnCryptMailto('" + r + "');\">" + name + "</a>");
        }

		//decrypts email address on page when a real user interacts
        function UnCryptMailto(s) {
            var n = 0;
            var r = "";
            for (var i = 0; i < s.length; i++) {
                n = s.charCodeAt(i);
                if (n >= 8364) {
                    n = 128;
                }
                r += String.fromCharCode(n - 1);
            }
            return r;
        }

        function linkTo_UnCryptMailto(s) {
            location.href = UnCryptMailto(s);
        }

    </script>
	
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="sub_nav" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Banner" runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Column_1" runat="Server">
   
    <div class="row marg-t-40 advisor-row">
        <asp:Literal ID="AdvisorName" runat="server"></asp:Literal>

        <div class="col-sm-4 col-md-3 advisor-image-col pad-r-50">
            <asp:Literal ID="AdvisorImage" runat="server"></asp:Literal>
			
            <div class="marg-t-10">
                <asp:Literal ID="AdvisorPhone" runat="server"></asp:Literal>
            </div>
			
            <div class="font-14 marg-t-10">
                <i class="fa fa-envelope marg-r-5 font-18"></i>
                <asp:Literal ID="AdvisorEmail" runat="server"></asp:Literal>
            </div>
			
            <div class="font-14 marg-t-10">
                <a href="<%= vCard  %>">
					<i class="marg-r-5">
						<img src="/images/v_card.png" width="20" />
					</i>
				Download Business vCard</a>
            </div>
			
            <div class="font-14 marg-t-10">
                <a href="https://join.me/" target="_blank">
					<i class="marg-r-5 marg-l-neg-5">
						<img src="/images/small_join_me.png" width="25" />
					</i>
				Join Me</a>
            </div>
			
            <div class="font-14 marg-t-10">
                <a href="../" target="_blank">
					<i class='fa fa-arrow-left marg-r-5 font-18'></i>
				Back to Advisor Page</a>
            </div>
        </div>

        <div class="advisor-favorites">
            <div class="col-sm-8 col-md-8 advisor-bio-col pad-l-0"  ng-app="tellFriendApp" ng-controller="tellFriendCtrl as tell" ng-form name="formTellFriend">                

                <input type="hidden" value="<%= RIA %>" id="ria" ng-model="tell.ria" />

                <div class="font-20 font-d-blue">
                    <div class="font-16 marg-t-10 border-b-l-l-gray pad-b-20">                        
                        <p>If you have friends or family who may benefit from working with me, please provide their contact information and I will be happy to provide them with more information.</p>
                        <p>Thank you.</p>
                    </div>
                </div>
				
                <div class="col-xs-12 col-sm-12 col-lg-6 ">
                    <h3 class="font-d-grey"><i>Your friend's information</i></h3>
					
                    <div class="form-group">
                        <label class="control">
                            First name*
                         <input type="text" class="form-control" placeholder="Friend's first name" id="name_first_friend" required="required" ng-model="tell.name_first_friend" />
                        </label>                       
                    </div>
					
                    <div class="form-group">
                        <label class="control">
                            Last name*
                         <input type="text" class="form-control" placeholder="Friend's last name" id="name_last_friend" ng-model="tell.name_last_friend" required="required" />
                        </label>
                    </div>
					
                     <div class="form-group" >
                        <label class="control">
                            Email*
                         <input type="email" class="form-control" placeholder="Friend's email address" id="email_friend" required="required" ng-model="tell.email_friend" />
                        </label>                          
                    </div>
					
                    <div class="form-group">
                        <label class="control">
                            Confirm email*
                        <input type="text" class="form-control"  placeholder="Confirm friend's email" id="email_friend_2"  ng-model="tell.email_friend_2" match="tell.email_friend" />
                        </label>
                        
                        <div ng-show="app.emailConfirm.$error.mismatch">
							<span class="msg-error">Email and Confirm Email must match.</span>
                        </div>        
                    </div>
					
                    <div class="form-group">
                        <label class="control">
                            Phone number*
                         <input type="tel" class="form-control" placeholder="Friend's phone number" id="phone_friend" required="required"  ng-model="tell.phone_friend" />
                        </label>
                    </div>
                </div>
				
                <div class="col-xs-12 col-sm-12 col-lg-6 ">
                    <h3 class="font-d-grey"><i>Your information</i></h3>
                    
					<div class="form-group">
                        <label class="control">
                            First name*
                         <input type="text" class="form-control" placeholder="Your first name" id="name_first" required="required"  ng-model="tell.name_first" />
                        </label>
                    </div>
					
                    <div class="form-group">
                        <label class="control">
                            Last name*
                         <input type="text" class="form-control" placeholder="Your last name" id="name_last" required="required" ng-model="tell.name_last" />
                        </label>
                    </div>
					
                    <div class="form-group">
                        <label class="control">
                            Email*
                         <input type="email" class="form-control" placeholder="Your email address" id="email" required="required" ng-model="tell.email" />
                        </label>
                    </div>
					
                    <div class="form-group">
                        <label class="control">
                            Notes
                         <textarea class="form-control" placeholder="Your notes" id="notes" rows="5" ng-model="tell.notes"></textarea>
                        </label>
                    </div>
				</div>

                <div class="col-xs-12 col-sm-12 col-lg-12 marg-b-40">  
					<span ng-style="{opacity : formTellFriend.$valid ? '0' : '1'}">*required field</span>
                    <a href="#" class="green-button width-350px display-block font-18 marg-t-20"  id="tellFriendButton" ng-click="tell.submit()">Submit</a>                    
                </div>                   
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="subBanner" runat="Server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="before_body_close" runat="Server">    
</asp:Content>
