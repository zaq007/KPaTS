(function($)
{
	$.Redactor.prototype.questionmarkup = function()
	{
		return {
			init: function()
			{
				var self = this;

				var button = this.button.add('questionmarkup', "Attach question", false);
				var $dropdown = this.button.addDropdown(button);

				$dropdown.width(242);
				this.questionmarkup.rebuildQuestionList($dropdown);

				$(".questions").on("questionListChanged", function(event) {
					self.questionmarkup.rebuildQuestionList($dropdown);
				})
			},
			rebuildQuestionList: function($dropdown)
			{
			    $dropdown.html("");
				var self = this;
				var func = function(e)
				{
				    e.preventDefault();
					self.questionmarkup.set($(e.currentTarget).data('question-id'));
				};

                if ($(".question").length > 0) {
				    $(".question").each(function (index, element) {
				        var questionId = $(element).data("question-id");
				        var $questionLink = $("<a href='#' data-question-id='" + questionId + "'>Question #" + (questionId + 1) + "</a>");
				        $questionLink.on('click', func);

				        $dropdown.append($questionLink);
				    })
                }
				else {
                    var $noQuestions = $("<a>No questions have been added</a>");
                    $dropdown.append($noQuestions);
                }
			},
			set: function(questionId)
			{
			    questionId++;
			    this.selection.replaceWithHtml("<abbr class='attached-question' title='Answer for the question #" + questionId + "'>" + this.range.extractContents().textContent + "</abbr>");
			}
		};
	};
})(jQuery);