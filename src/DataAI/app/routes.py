from app import app
from flask import  request, jsonify
from threading import Thread
from app import ai_service as aiService
from app import grpcServer as grpc_server
@app.route('/')
@app.route('/index')
def index():
    return "Hello, World!"
@app.route('/ai', methods=['POST'])
def ai():
    if request.content_type == "text/plain":
        prompt = request.data.decode('utf-8')
        if not prompt:
            return jsonify({'error': 'No prompt provided'}), 400
        #todo : api key of api.groq.com should be moved to out side of the code
        ai_service = aiService.GroqService("https://api.groq.com/openai/v1/chat/completions","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")
        ans = ai_service.get_answer(prompt=prompt)
        return jsonify(ans), 200
    else:
        return jsonify({"error": "Content-Type must be text/plain"}), 400
    
def run_grpc():
    grpc_server.serve()

#if __name__ == '__main__':
    # Run gRPC server in a separate thread
grpc_thread = Thread(target=run_grpc, daemon=None)
grpc_thread.start()