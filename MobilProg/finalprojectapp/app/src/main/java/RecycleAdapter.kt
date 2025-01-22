import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.levente.kovacs.finalprojectapplication.R

class RecycleAdapter(private val rows: MutableList<String>) : RecyclerView.Adapter<RecycleAdapter.TextViewHolder>() {

        class TextViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
            val textViewRow: TextView = itemView.findViewById(R.id.textViewRow)
        }

         override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TextViewHolder {
            val view = LayoutInflater.from(parent.context)
                .inflate(R.layout.recycle_view_row, parent, false)
            return TextViewHolder(view)
        }

        override fun onBindViewHolder(holder: TextViewHolder, position: Int) {
            holder.textViewRow.text = rows[position]
        }

        override fun getItemCount(): Int = rows.size
}
