from flask_app.config.mysqlconnection import connectToMySQL
from flask_app import DATABASE

class User:
    def __init__(self, data):
        self.id = data['id']
        self.business_name = data['business_name']
        self.location = "Miami"
        self.last_name = data['last_name']
        self.email = data['email']
        self.phone = data['phone']
        self.pipeline_status = data['pipeline_status']
        self.lat = data['lat']
        self.lng = data['lng']
        self.user_id = data['user_id']
        self.created_at = data['created_at']
        self.updated_at = data['updated_at']

    @classmethod
    def get_location(cls,data):
        query = "SELECT location FROM users WHERE user_id = %(user_id)s;"
        results = connectToMySQL(DATABASE).query_db(query,data)
        if len(results) < 1:
            return False
        row = results[0]
        this_user_location = cls(row)
        return this_user_location