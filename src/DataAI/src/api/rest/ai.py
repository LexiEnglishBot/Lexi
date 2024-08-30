from flask import Blueprint, request, jsonify
from services.ai_service import GroqService as aiSrevice

user_bp = Blueprint('ai', __name__)

@user_bp.route('/ai', methods=['POST'])
def ai():
    prompt = request.get_json().get("prompt")
    if not prompt:
        return jsonify({'error': 'No prompt provided'}), 400
    
    ai_service = aiSrevice("https://api.groq.com","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")
    ans = ai_service.get_answer(prompt=prompt)
    return jsonify(ans), 200
